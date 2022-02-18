using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROGRESSTRACKER.API.Helpers.Mapper.Models;
using PROGRESSTRACKER.API.Helpers.Return;
using PROGRESSTRACKER.API.Manager.Repository;
using PROGRESSTRACKER.ENTITIES;
using PROGRESSTRACKER.HELPERS.Region;
using PROGRESSTRACKER.SERVICES.DTO.Auth.User;
using PROGRESSTRACKER.SERVICES.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserRelationRepository _userRelationRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IJwtAuthManager _tokenManager;
        private readonly IMapper _mapper;

        public AuthController(IAuthRepository authRepository, IUserRelationRepository userRelationRepository, 
            ITeamRepository teamRepository, IJwtAuthManager tokenManager, IMapper mapper)
        {
            _authRepository = authRepository;
            _userRelationRepository = userRelationRepository;
            _teamRepository = teamRepository;
            _tokenManager = tokenManager;
            _mapper = mapper;
        }

        private string GetHMAC(string userId, string email)
        {
            email = email ?? "";

            using (var hmacsha256 = new HMACSHA256(Encoding.UTF8.GetBytes(email)))
            {
                var hash = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(userId));
                return Convert.ToBase64String(hash).Replace("/", string.Empty);
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDto dto)
        {
            if (!_authRepository.IsUserExists(dto.Email))
                return Ok("email_doesnt_exists".SetResponse(201, new { }));

            var user = _authRepository.Login(dto);

            if (user == null || user.IsBlocked || user.IsDeleted)
                return Ok("exception".SetResponse(401, new { }));

            var claims = _tokenManager.GenerateClaims(user.Id.ToString(), string.Format("{0} {1}", user.Name, user.Surname), user.Email);

            var generatedToken = _tokenManager.Create(claims);

            user.AccessToken = generatedToken;
            user.IsOnline = true;
            user.LastLogin = RegionService.CurrentDateTime();

            _authRepository.Update(user);

            return Ok("signin_success".SetResponse(200, _mapper.Map<UserResponseModel>(user)));
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (_authRepository.IsUserExists(dto.Username))
                return Ok("username_exists".SetResponse(201, new { }));

            if (_authRepository.IsUserExists(dto.Email))
                return Ok("email_exists".SetResponse(201, new { }));

            //if (!ValidationService.IsPhonenumberValid(dto.PhoneNumber))
            //    return Ok("phonenumber_incorrect".SetResponse(401, new { }));

            var user = await _authRepository.Register(dto);

            if (user == null || user.IsBlocked || user.IsDeleted)
                return Ok("exception".SetResponse(401, new { }));

            var claims = _tokenManager.GenerateClaims(user.Id.ToString(), string.Format("{0} {1}", user.Name, user.Surname), user.Email);

            var generatedToken = _tokenManager.Create(claims);

            user.AccessToken = generatedToken;
            user.ApplicationId = GetHMAC(user.Id.ToString(), user.Email);

            var team = new Team()
            {
                Name = user.Name + user.Surname + "'s Workspace",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            await _teamRepository.AddTeam(team);
            var relation = new UserRelation()
            {
                TeamId = team.Id,
                UserId = user.Id
            };
            await _userRelationRepository.Add(relation);
            _authRepository.Update(user);

            return Ok("register_success".SetResponse(200, _mapper.Map<UserResponseModel>(user)));
        }
    }
}

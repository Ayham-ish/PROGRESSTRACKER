using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROGRESSTRACKER.API.Helpers.Mapper.Models;
using PROGRESSTRACKER.API.Helpers.Return;
using PROGRESSTRACKER.ENTITIES;
using PROGRESSTRACKER.SERVICES.DTO;
using PROGRESSTRACKER.SERVICES.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IUserRelationRepository _userRelationRepository;
        private readonly IMapper _mapper;

        public TeamsController(IUserRepository userRepository, ITeamRepository teamRepository, IGroupRepository groupRepository, IUserRelationRepository userRelationRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _teamRepository = teamRepository;
            _groupRepository = groupRepository;
            _userRelationRepository = userRelationRepository;
            _mapper = mapper;
        }

        [HttpGet("GetTeams")]
        public IActionResult GetTeams()
        {
            var teams = _teamRepository.GetTeams();
            foreach(Team team in teams)
            {
                var users = _userRepository.GetUsers(x => !x.IsDeleted);
                foreach(User user in users)
                {
                    //var userrelations = _userRelationRepository.GetAll(x => x.UserId == user.Id, User);

                }
            }
            return Ok("Success".SetResponse(200, _mapper.Map<List<TeamResponse>>(teams)));
        }

        [HttpGet("GetGroups")]
        public IActionResult GetGroups(int teamId) 
        {
            var team = _teamRepository.GetTeam(x => x.Id == teamId);
            //var groups = _groupRepository.GetGroups(x => x.TeamId == team.Id && x.IsDeleted == false);

            return Ok(/*"Success".SetResponse(200, _mapper.Map<List<GroupResponse>>(groups))*/);
           
        }
        [HttpPost("AddGroups")]
        public IActionResult AddGroups(GroupDto dto) 
        {

            return Ok();
        }

    }
}

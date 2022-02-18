using PROGRESSTRACKER.DAL.Interface;
using PROGRESSTRACKER.ENTITIES;
using PROGRESSTRACKER.HELPERS.Region;
using PROGRESSTRACKER.SERVICES.DTO.Auth.User;
using PROGRESSTRACKER.SERVICES.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.SERVICES.Repositories.Implementation
{
    public class AuthRepository : IAuthRepository
    {
        protected static IRepository<User> _userRepository;
        protected static IRepository<Admin> _adminRepository;

        public AuthRepository(IRepository<User> userRepository, IRepository<Admin> adminRepository)
        {
            _userRepository = userRepository;
            _adminRepository = adminRepository;
        }

        public User GetUser(Expression<Func<User, bool>> predicate)
        {
            return _userRepository.FindAllByCondition(predicate).First();
        }
        public User GetUser(Expression<Func<User, bool>> predicate, params Expression<Func<User, object>>[] includes)
        {
            return _userRepository.FindByConditionWithIncludes(predicate, includes);
        }
        public bool IsUserExists(string item)
        {
            var user = _userRepository.FindByCondition(x => x.PhoneNumber == item || x.Email == item);
            if (user == null)
                return false;

            return true;
        }

        public User Login(LoginDto dto)
        {
            return _userRepository.FindByCondition(x => x.Email == dto.Email && !x.IsDeleted && !x.IsBlocked);
        }

        public async Task<User> Register(RegisterDto dto)
        {
            return await _userRepository.Insert(new User
            {
                Name = dto.Name,
                Surname = dto.Surname,
                DeviceToken = dto.DeviceToken,
                AccessToken = dto.AccessToken,
                Email = dto.Email,
                Password = dto.Password,
                GenderId = dto.GenderId,
                UserTypeId = dto.UserTypeId,
                ApplicationId = dto.ApplicationId,
                CreatedAt = RegionService.CurrentDateTime(),
                UpdatedAt = RegionService.CurrentDateTime(),
                LastLogin = RegionService.CurrentDateTime(),
                IsOnline = true,
                IsBlocked = false,
                
            });

        }



        public void Update(User entity)
        {
            entity.UpdatedAt = RegionService.CurrentDateTime();
            _userRepository.Update(entity);
        }



        public Admin AdminLogin(string username, string password)
        {
            var admin = _adminRepository.FindByCondition(x => x.Username == username && x.Password.Equals(password) && !x.IsDeleted);
            if (admin == null)
                return admin;
            else
            {
                admin.LastLogin = RegionService.CurrentDateTime();
                _adminRepository.Update(admin);
                return admin;
            }
        }


        public Admin GetAdmin(Expression<Func<Admin, bool>> predicate)
        {
            return _adminRepository.FindAllByCondition(predicate).First();
        }

        public void AdminUpdate(Admin entity)
        {
            entity.UpdatedAt = RegionService.CurrentDateTime();
            _adminRepository.Update(entity);
        }
    }
}

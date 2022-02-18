using PROGRESSTRACKER.DAL.Interface;
using PROGRESSTRACKER.ENTITIES;
using PROGRESSTRACKER.HELPERS.Region;
using PROGRESSTRACKER.SERVICES.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.SERVICES.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly IRepository<User> _userRepository;
        

        public UserRepository(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AddUser(User entity)
        {
            entity.CreatedAt = RegionService.CurrentDateTime();
            entity.UpdatedAt = RegionService.CurrentDateTime();
            return await _userRepository.Insert(entity);
        }

        public async Task BlockUser(int id)
        {
            var user = _userRepository.FindByCondition(x => x.Id == id);
            user.IsDeleted = true;
            await _userRepository.Update(user);
        }

        public User GetUser(int id)
        {
            return _userRepository.FindByCondition(x => x.Id == id);
        }

        public List<User> GetUsers(Expression<Func<User, bool>> predicate, params Expression<Func<User, object>>[] includes)
        {
            return _userRepository.FindAllByConditionWithIncludes(predicate, includes).ToList();
        }


        public List<User> GetUsers()
        {
            return _userRepository.FindAllByCondition(x => !x.IsDeleted);
        }

        public bool IfUserExist(string email)
        {
            var exist = _userRepository.FindByCondition(x => x.Email == email && !x.IsDeleted);
            if (exist != null)
            {
                return true;
            }
            return false;
        }

        public async Task Update(User entity)
        {
            User user = GetUser(entity.Id);
            user.Name = entity.Name;
            user.Surname = entity.Surname;
            user.Email = entity.Email;
            user.Password = entity.Password;
            user.GenderId = entity.GenderId;
            user.UserTypeId = entity.UserTypeId;
            user.UpdatedAt = RegionService.CurrentDateTime();
            await _userRepository.Update(user);
        }
    }
}

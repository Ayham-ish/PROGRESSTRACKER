using PROGRESSTRACKER.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.SERVICES.Repositories.Interface
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        List<User> GetUsers(Expression<Func<User, bool>> predicate, params Expression<Func<User, object>>[] includes);
        

        User GetUser(int id);
        Task<User> AddUser(User entity);
        Task Update(User entity);
        Task BlockUser(int id);
        bool IfUserExist(string email);
    }
}

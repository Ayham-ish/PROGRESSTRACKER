using PROGRESSTRACKER.ENTITIES;
using PROGRESSTRACKER.SERVICES.DTO.Auth.Admin;
using PROGRESSTRACKER.SERVICES.DTO.Auth.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.SERVICES.Repositories.Interface
{
    public interface IAuthRepository
    {
        User GetUser(Expression<Func<User, bool>> predicate);
        User GetUser(Expression<Func<User, bool>> predicate, params Expression<Func<User, object>>[] includes);
        User Login(LoginDto dto);
        Task<User> Register(RegisterDto dto);
        void Update(User entity);
        bool IsUserExists(string item);
        Admin GetAdmin(Expression<Func<Admin, bool>> predicate);
        Admin AdminLogin(string username, string password);
        void AdminUpdate(Admin entity);
    }
}

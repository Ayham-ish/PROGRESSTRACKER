using PROGRESSTRACKER.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.SERVICES.Repositories.Interface
{
    public interface IAdminRepository
    {
        List<Admin> GetAdmins();
       
        List<Admin> GetAdmins(Expression<Func<Admin, bool>> predicate, params Expression<Func<Admin, object>>[] includes);

        Admin GetAdmin(Expression<Func<Admin, bool>> predicate, params Expression<Func<Admin, object>>[] includes);

        Task<Admin> Add(Admin entity);

        Task Update(Admin entity);

        Task Delete(Admin entity);
    }
}

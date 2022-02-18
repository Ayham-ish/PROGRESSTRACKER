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
    public class AdminRepository : IAdminRepository
    {
        private readonly IRepository<Admin> _adminRepository;

        public AdminRepository(IRepository<Admin> adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public List<Admin> GetAdmins()
        {
            return _adminRepository.GetAll();
        }

        public List<Admin> GetAdmins(Expression<Func<Admin, bool>> predicate, params Expression<Func<Admin, object>>[] includes)
        {
            return _adminRepository.FindAllByConditionWithIncludes(predicate, includes).ToList();
        }

        public Admin GetAdmin(Expression<Func<Admin, bool>> predicate, params Expression<Func<Admin, object>>[] includes)
        {
            return _adminRepository.FindByConditionWithIncludes(predicate, includes);
        }

        public async Task<Admin> Add(Admin entity)
        {
            entity.CreatedAt = RegionService.CurrentDateTime();
            entity.UpdatedAt = RegionService.CurrentDateTime();
            return await _adminRepository.Insert(entity);
        }

        public async Task Update(Admin entity)
        {
            entity.UpdatedAt = RegionService.CurrentDateTime();
            await _adminRepository.Update(entity);
        }

        public async Task Delete(Admin entity)
        {
            entity.UpdatedAt = RegionService.CurrentDateTime();
            await _adminRepository.Delete(entity);
        }

        
    }
}

using PROGRESSTRACKER.DAL.Interface;
using PROGRESSTRACKER.ENTITIES;
using PROGRESSTRACKER.SERVICES.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using System.Threading.Tasks;

namespace PROGRESSTRACKER.SERVICES.Repositories.Implementation
{
    public class GroupRepository : IGroupRepository
    {
        private readonly IRepository<Group> _groupRepository;



        public GroupRepository(IRepository<Group> groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<Group> AddGroup(Group entity)
        {
            return await _groupRepository.Insert(entity);
        }


        public async Task DeleteGroup(Group entity)
        {
            await _groupRepository.Delete(entity);
        }


        public Group GetGroup(Expression<Func<Group, bool>> predicate, params Expression<Func<Group, object>>[] includes)
        {
            return _groupRepository.FindByConditionWithIncludes(predicate, includes);
        }

        public List<Group> GetGroups()
        {
            return _groupRepository.GetAll();
        }

        public List<Group> GetGroups(Expression<Func<Group, bool>> predicate, params Expression<Func<Group, object>>[] includes)
        {
            return _groupRepository.FindAllByConditionWithIncludes(predicate, includes).ToList();
        }

        public List<Group> GetGroups(params Expression<Func<Group, object>>[] includes)
        {
            return _groupRepository.FindAllWithIncludes(includes).ToList();
        }

        public async Task UpdateGroup(Group entity)
        {
            await _groupRepository.Update(entity);
        }
    }
}

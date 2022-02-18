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
    public class UserRelationRepository : IUserRelationRepository
    {
        private readonly IRepository<UserRelation> _userRelationRepository;



        public UserRelationRepository(IRepository<UserRelation> userRelationRepository)
        {
            _userRelationRepository = userRelationRepository;
        }

        public async Task<UserRelation> Add(UserRelation entity)
        {
            return await _userRelationRepository.Insert(entity);
        }


        public async Task Delete(UserRelation entity)
        {
            await _userRelationRepository.Delete(entity);
        }


        public UserRelation Get(Expression<Func<UserRelation, bool>> predicate, params Expression<Func<UserRelation, object>>[] includes)
        {
            return _userRelationRepository.FindByConditionWithIncludes(predicate, includes);
        }

        public List<UserRelation> GetAll()
        {
            return _userRelationRepository.GetAll();
        }

        public List<UserRelation> GetAll(Expression<Func<UserRelation, bool>> predicate, params Expression<Func<UserRelation, object>>[] includes)
        {
            return _userRelationRepository.FindAllByConditionWithIncludes(predicate, includes).ToList();
        }

        public List<UserRelation> GetAll(params Expression<Func<UserRelation, object>>[] includes)
        {
            return _userRelationRepository.FindAllWithIncludes(includes).ToList();
        }

        public async Task Update(UserRelation entity)
        {
            await _userRelationRepository.Update(entity);
        }
    }
}

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
    public class TimeTrackerTagRelationRepository : ITimeTrackerTagRelationRepository
    {
        private readonly IRepository<TimeTrackerTagRelation> _timeTrackerTagRelationRepository;



        public TimeTrackerTagRelationRepository(IRepository<TimeTrackerTagRelation> TimeTrackerTagRelationRepository)
        {
            _timeTrackerTagRelationRepository = TimeTrackerTagRelationRepository;
        }

        public async Task<TimeTrackerTagRelation> Add(TimeTrackerTagRelation entity)
        {
            return await _timeTrackerTagRelationRepository.Insert(entity);
        }


        public async Task Delete(TimeTrackerTagRelation entity)
        {
            await _timeTrackerTagRelationRepository.Delete(entity);
        }


        public TimeTrackerTagRelation Get(Expression<Func<TimeTrackerTagRelation, bool>> predicate, params Expression<Func<TimeTrackerTagRelation, object>>[] includes)
        {
            return _timeTrackerTagRelationRepository.FindByConditionWithIncludes(predicate, includes);
        }

        public List<TimeTrackerTagRelation> GetAll()
        {
            return _timeTrackerTagRelationRepository.GetAll();
        }

        public List<TimeTrackerTagRelation> GetAll(Expression<Func<TimeTrackerTagRelation, bool>> predicate, params Expression<Func<TimeTrackerTagRelation, object>>[] includes)
        {
            return _timeTrackerTagRelationRepository.FindAllByConditionWithIncludes(predicate, includes).ToList();
        }

        public List<TimeTrackerTagRelation> GetAll(params Expression<Func<TimeTrackerTagRelation, object>>[] includes)
        {
            return _timeTrackerTagRelationRepository.FindAllWithIncludes(includes).ToList();
        }

        public async Task Update(TimeTrackerTagRelation entity)
        {
            await _timeTrackerTagRelationRepository.Update(entity);
        }
    }
}

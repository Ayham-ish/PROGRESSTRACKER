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
    public class TimeTrackerRepository : ITimeTrackerRepository
    {
        private readonly IRepository<TimeTracker> _timetrackerRepository;



        public TimeTrackerRepository(IRepository<TimeTracker> timeTrackerRepository)
        {
            _timetrackerRepository = timeTrackerRepository;
        }

        public async Task<TimeTracker> AddTimeTracker(TimeTracker entity)
        {
            return await _timetrackerRepository.Insert(entity);
        }


        public async Task DeleteTimeTracker(TimeTracker entity)
        {
            await _timetrackerRepository.Delete(entity);
        }


        public TimeTracker GetTimeTracker(Expression<Func<TimeTracker, bool>> predicate, params Expression<Func<TimeTracker, object>>[] includes)
        {
            return _timetrackerRepository.FindByConditionWithIncludes(predicate, includes);
        }

        public List<TimeTracker> GetTimeTrackers()
        {
            return _timetrackerRepository.GetAll();
        }

        public List<TimeTracker> GetTimeTrackers(Expression<Func<TimeTracker, bool>> predicate, params Expression<Func<TimeTracker, object>>[] includes)
        {
            return _timetrackerRepository.FindAllByConditionWithIncludes(predicate, includes).ToList();
        }

        public List<TimeTracker> GetTimeTrackers(params Expression<Func<TimeTracker, object>>[] includes)
        {
            return _timetrackerRepository.FindAllWithIncludes(includes).ToList();
        }

        public async Task UpdateTimeTracker(TimeTracker entity)
        {
            await _timetrackerRepository.Update(entity);
        }
    }
}

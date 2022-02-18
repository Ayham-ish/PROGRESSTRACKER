using PROGRESSTRACKER.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.SERVICES.Repositories.Interface
{
    public interface ITimeTrackerRepository
    {
        #region Create
        Task<TimeTracker> AddTimeTracker(TimeTracker entity);

        #endregion



        #region Read
        List<TimeTracker> GetTimeTrackers();
        List<TimeTracker> GetTimeTrackers(Expression<Func<TimeTracker, bool>> predicate, params Expression<Func<TimeTracker, object>>[] includes);
        List<TimeTracker> GetTimeTrackers(params Expression<Func<TimeTracker, object>>[] includes);
        TimeTracker GetTimeTracker(Expression<Func<TimeTracker, bool>> predicate, params Expression<Func<TimeTracker, object>>[] includes);

        #endregion


        #region Update
        Task UpdateTimeTracker(TimeTracker entity);

        #endregion


        #region Delete
        Task DeleteTimeTracker(TimeTracker entity);
        #endregion
    }
}

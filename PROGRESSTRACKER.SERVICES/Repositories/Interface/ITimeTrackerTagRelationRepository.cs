using PROGRESSTRACKER.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.SERVICES.Repositories.Interface
{
    public interface ITimeTrackerTagRelationRepository
    {
        #region Create
        Task<TimeTrackerTagRelation> Add(TimeTrackerTagRelation entity);

        #endregion



        #region Read
        List<TimeTrackerTagRelation> GetAll();
        List<TimeTrackerTagRelation> GetAll(Expression<Func<TimeTrackerTagRelation, bool>> predicate, params Expression<Func<TimeTrackerTagRelation, object>>[] includes);
        List<TimeTrackerTagRelation> GetAll(params Expression<Func<TimeTrackerTagRelation, object>>[] includes);
        TimeTrackerTagRelation Get(Expression<Func<TimeTrackerTagRelation, bool>> predicate, params Expression<Func<TimeTrackerTagRelation, object>>[] includes);

        #endregion


        #region Update
        Task Update(TimeTrackerTagRelation entity);

        #endregion


        #region Delete
        Task Delete(TimeTrackerTagRelation entity);
        #endregion
    }
}



using PROGRESSTRACKER.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.SERVICES.Repositories.Interface
{
    public interface IGroupRepository
    {
        #region Create
        Task<Group> AddGroup(Group entity);

        #endregion


        #region Read
        List<Group> GetGroups();
        List<Group> GetGroups(Expression<Func<Group, bool>> predicate, params Expression<Func<Group, object>>[] includes);
        List<Group> GetGroups(params Expression<Func<Group, object>>[] includes);
        Group GetGroup(Expression<Func<Group, bool>> predicate, params Expression<Func<Group, object>>[] includes);

        #endregion


        #region Update
        Task UpdateGroup(Group entity);

        #endregion


        #region Delete
        Task DeleteGroup(Group entity);
        #endregion
    }
}

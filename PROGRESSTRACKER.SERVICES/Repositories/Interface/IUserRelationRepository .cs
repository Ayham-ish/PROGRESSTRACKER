using PROGRESSTRACKER.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.SERVICES.Repositories.Interface
{
    public interface IUserRelationRepository
    {

        #region Create
        Task<UserRelation> Add(UserRelation entity);

        #endregion



        #region Read
        List<UserRelation> GetAll();
        List<UserRelation> GetAll(Expression<Func<UserRelation, bool>> predicate, params Expression<Func<UserRelation, object>>[] includes);
        List<UserRelation> GetAll(params Expression<Func<UserRelation, object>>[] includes);
        UserRelation Get(Expression<Func<UserRelation, bool>> predicate, params Expression<Func<UserRelation, object>>[] includes);

        #endregion


        #region Update
        Task Update(UserRelation entity);

        #endregion


        #region Delete
        Task Delete(UserRelation entity);
        #endregion
    }
}

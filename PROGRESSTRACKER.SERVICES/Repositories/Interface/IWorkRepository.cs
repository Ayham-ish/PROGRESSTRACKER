using PROGRESSTRACKER.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.SERVICES.Repositories.Interface
{
    public interface IWorkRepository
    {
        #region Create
        Task<Work> AddTask(Work entity);

        #endregion



        #region Read
        List<Work> GetTasks();
        List<Work> GetTasks(Expression<Func<Work, bool>> predicate, params Expression<Func<Work, object>>[] includes);
        List<Work> GetTasks(params Expression<Func<Work, object>>[] includes);
        Work GetTask(Expression<Func<Work, bool>> predicate, params Expression<Func<Work, object>>[] includes);

        #endregion


        #region Update
        Task UpdateTask(Work entity);

        #endregion


        #region Delete
        Task DeleteTask(Work entity);
        #endregion
    }
}

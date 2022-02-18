using PROGRESSTRACKER.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.SERVICES.Repositories.Interface
{
    public interface IProjectRepository
    {
        #region Create
        Task<Project> AddProject(Project entity);

        #endregion



        #region Read
        List<Project> GetProjects();
        List<Project> GetProjects(Expression<Func<Project, bool>> predicate, params Expression<Func<Project, object>>[] includes);
        List<Project> GetProjects(params Expression<Func<Project, object>>[] includes);
        Project GetProject(Expression<Func<Project, bool>> predicate, params Expression<Func<Project, object>>[] includes);

        #endregion


        #region Update
        Task UpdateProject(Project entity);

        #endregion


        #region Delete
        Task DeleteProject(Project entity);
        #endregion
    }
}

using PROGRESSTRACKER.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.SERVICES.Repositories.Interface
{
    public interface ITeamRepository
    {
        #region Create
        Task<Team> AddTeam(Team entity);

        #endregion



        #region Read
        List<Team> GetTeams();
        List<Team> GetTeams(Expression<Func<Team, bool>> predicate, params Expression<Func<Team, object>>[] includes);
        List<Team> GetTeams(params Expression<Func<Team, object>>[] includes);
        Team GetTeam(Expression<Func<Team, bool>> predicate, params Expression<Func<Team, object>>[] includes);

        #endregion


        #region Update
        Task UpdateTeam(Team entity);

        #endregion


        #region Delete
        Task DeleteTeam(Team entity);
        #endregion
    }
}

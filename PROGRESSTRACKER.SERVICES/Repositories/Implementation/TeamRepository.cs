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
    public class TeamRepository : ITeamRepository
    {
        private readonly IRepository<Team> _teamRepository;



        public TeamRepository(IRepository<Team> teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<Team> AddTeam(Team entity)
        {
            return await _teamRepository.Insert(entity);
        }


        public async Task DeleteTeam(Team entity)
        {
            await _teamRepository.Delete(entity);
        }


        public Team GetTeam(Expression<Func<Team, bool>> predicate, params Expression<Func<Team, object>>[] includes)
        {
            return _teamRepository.FindByConditionWithIncludes(predicate, includes);
        }

        public List<Team> GetTeams()
        {
            return _teamRepository.GetAll();
        }

        public List<Team> GetTeams(Expression<Func<Team, bool>> predicate, params Expression<Func<Team, object>>[] includes)
        {
            return _teamRepository.FindAllByConditionWithIncludes(predicate, includes).ToList();
        }

        public List<Team> GetTeams(params Expression<Func<Team, object>>[] includes)
        {
            return _teamRepository.FindAllWithIncludes(includes).ToList();
        }

        public async Task UpdateTeam(Team entity)
        {
            await _teamRepository.Update(entity);
        }
    }
}

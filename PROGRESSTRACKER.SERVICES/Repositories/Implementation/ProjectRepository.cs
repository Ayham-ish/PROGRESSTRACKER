using PROGRESSTRACKER.DAL.Interface;
using PROGRESSTRACKER.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROGRESSTRACKER.SERVICES.Repositories.Interface;
using System.Linq.Expressions;

namespace PROGRESSTRACKER.SERVICES.Repositories.Implementation
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IRepository<Project> _projectRepository;



        public ProjectRepository(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Project> AddProject(Project entity)
        {
            return await _projectRepository.Insert(entity);
        }


        public async Task DeleteProject(Project entity)
        {
            await _projectRepository.Delete(entity);
        }


        public Project GetProject(Expression<Func<Project, bool>> predicate, params Expression<Func<Project, object>>[] includes)
        {
            return _projectRepository.FindByConditionWithIncludes(predicate, includes);
        }

        public List<Project> GetProjects()
        {
            return _projectRepository.GetAll();
        }

        public List<Project> GetProjects(Expression<Func<Project, bool>> predicate, params Expression<Func<Project, object>>[] includes)
        {
            return _projectRepository.FindAllByConditionWithIncludes(predicate, includes).ToList();
        }

        public List<Project> GetProjects(params Expression<Func<Project, object>>[] includes)
        {
            return _projectRepository.FindAllWithIncludes(includes).ToList();
        }

        public async Task UpdateProject(Project entity)
        {
            await _projectRepository.Update(entity);
        }
    }
}

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
    public class WorkRepository : IWorkRepository
    {
        private readonly IRepository<Work> _workRepository;



        public WorkRepository(IRepository<Work> workRepository)
        {
            _workRepository = workRepository;
        }

        public async Task<Work> AddTask(Work entity)
        {
            return await _workRepository.Insert(entity);
        }


        public async Task DeleteTask(Work entity)
        {
            await _workRepository.Delete(entity);
        }


        public Work GetTask(Expression<Func<Work, bool>> predicate, params Expression<Func<Work, object>>[] includes)
        {
            return _workRepository.FindByConditionWithIncludes(predicate, includes);
        }

        public List<Work> GetTasks()
        {
            return _workRepository.GetAll();
        }

        public List<Work> GetTasks(Expression<Func<Work, bool>> predicate, params Expression<Func<Work, object>>[] includes)
        {
            return _workRepository.FindAllByConditionWithIncludes(predicate, includes).ToList();
        }

        public List<Work> GetTasks(params Expression<Func<Work, object>>[] includes)
        {
            return _workRepository.FindAllWithIncludes(includes).ToList();
        }

        public async Task UpdateTask(Work entity)
        {
            await _workRepository.Update(entity);
        }
    }
}

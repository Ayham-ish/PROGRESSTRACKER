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
    public class DailyReportRepository : IDailyReportRepository
    {
        private readonly IRepository<DailyReport> _dailyreportRepository;



        public DailyReportRepository(IRepository<DailyReport> dailyreportRepository)
        {
            _dailyreportRepository = dailyreportRepository;
        }

        public async Task<DailyReport> AddDailyReport(DailyReport entity)
        {
            return await _dailyreportRepository.Insert(entity);
        }


        public async Task DeleteDailyReport(DailyReport entity)
        {
            await _dailyreportRepository.Delete(entity);
        }


        public DailyReport GetDailyReport(Expression<Func<DailyReport, bool>> predicate, params Expression<Func<DailyReport, object>>[] includes)
        {
            return _dailyreportRepository.FindByConditionWithIncludes(predicate, includes);
        }

        public List<DailyReport> GetDailyReports()
        {
            return _dailyreportRepository.GetAll();
        }

        public List<DailyReport> GetDailyReports(Expression<Func<DailyReport, bool>> predicate, params Expression<Func<DailyReport, object>>[] includes)
        {
            return _dailyreportRepository.FindAllByConditionWithIncludes(predicate, includes).ToList();
        }

        public List<DailyReport> GetDailyReports(params Expression<Func<DailyReport, object>>[] includes)
        {
            return _dailyreportRepository.FindAllWithIncludes(includes).ToList();
        }

        public async Task UpdateDailyReport(DailyReport entity)
        {
            await _dailyreportRepository.Update(entity);
        }
    }
}

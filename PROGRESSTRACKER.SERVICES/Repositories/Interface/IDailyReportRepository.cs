using PROGRESSTRACKER.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.SERVICES.Repositories.Interface
{
    public interface IDailyReportRepository
    {
        #region Create
        Task<DailyReport> AddDailyReport(DailyReport entity);

        #endregion



        #region Read
        List<DailyReport> GetDailyReports();
        List<DailyReport> GetDailyReports(Expression<Func<DailyReport, bool>> predicate, params Expression<Func<DailyReport, object>>[] includes);
        List<DailyReport> GetDailyReports(params Expression<Func<DailyReport, object>>[] includes);
        DailyReport GetDailyReport(Expression<Func<DailyReport, bool>> predicate, params Expression<Func<DailyReport, object>>[] includes);

        #endregion


        #region Update
        Task UpdateDailyReport(DailyReport entity);

        #endregion


        #region Delete
        Task DeleteDailyReport(DailyReport entity);
        #endregion
    }
}

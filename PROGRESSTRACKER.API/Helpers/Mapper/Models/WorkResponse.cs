using System.Collections.Generic;

namespace PROGRESSTRACKER.API.Helpers.Mapper.Models
{
    public class WorkResponse
    {
        public string Name { get; set; }
        public List<DailyReportResponse> DailyReports { get; set; }
        //public ProjectResponse Project { get; set; }
        public virtual PublicUserResponse User { get; set; }
    }
}
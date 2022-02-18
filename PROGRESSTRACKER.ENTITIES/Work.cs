using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.ENTITIES
{
    public class Work : BaseEntity
    {
        public string Name { get; set; }
        public List<DailyReport> DailyReports { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public virtual User User { get; set; }
        public int? UserId { get; set; }
    }
}

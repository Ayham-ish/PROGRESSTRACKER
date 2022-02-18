using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.SERVICES.DTO.TimeTracker
{
    public class TimeTrackerDto
    {
        public string Description { get; set; }
        //public DateTime Timestamp { get; set; }
        public bool IsActive { get; set; }
        public int? ProjectId { get; set; }
    }
}

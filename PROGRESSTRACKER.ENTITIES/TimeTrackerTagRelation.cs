using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.ENTITIES
{
    public class TimeTrackerTagRelation : BaseEntity
    {
        public virtual Tag Tag { get; set; }
        public int? TagId { get; set; }
        public virtual TimeTracker TimeTracker { get; set; }
        public int? TimeTrackerId { get; set; }
    }
}

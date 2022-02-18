using System;
using System.Collections.Generic;

namespace PROGRESSTRACKER.ENTITIES
{
    public class TimeTracker : BaseEntity
    {
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime EndPoint { get; set; }
        public DateTime StartPoint { get; set; }
        public bool IsActive { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual Project Project { get; set; }
        public int? ProjectId { get; set; }

    }
}

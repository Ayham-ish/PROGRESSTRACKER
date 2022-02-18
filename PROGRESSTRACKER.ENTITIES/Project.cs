using System.Collections.Generic;

namespace PROGRESSTRACKER.ENTITIES
{
    public class Project : BaseEntity
    {
       
        public string Name { get; set; }
        public Client Client { get; set; }
        public int? ClientId { get; set; } 
        public double Progress { get; set; }
        public List<Work> WorkList { get; set; }
        public List<TimeTracker> TimeTrackers { get; set; }

    }
}
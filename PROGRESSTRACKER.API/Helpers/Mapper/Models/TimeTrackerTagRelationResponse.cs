using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.API.Helpers.Mapper.Models
{
    public class TimeTrackerTagRelationResponse
    {
        public TimeTrackerResponse TimeTracker { get; set; }
        public TagResponse Tag { get; set; }
    }
}

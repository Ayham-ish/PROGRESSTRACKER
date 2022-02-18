using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.SERVICES.DTO.TimeTracker
{
    public class AddProjectToTimeTrackerDto
    {
        public int TimeTrackerId { get; set; }
        public int ProjectId { get; set; }
    }
}

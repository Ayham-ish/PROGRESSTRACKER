using PROGRESSTRACKER.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.API.Helpers.Mapper.Models
{
    public class ProjectResponse
    {
        public string Name { get; set; }
        public ClientResponse Client { get; set; }
        public double Progress { get; set; }
        public List<GroupResponse> Groups { get; set; }
        public List<WorkResponse> WorkList { get; set; }
        public List<ProjectTimeTrackersResponse> TimeTrackers { get; set; }
    }
}

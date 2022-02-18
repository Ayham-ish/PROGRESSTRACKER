using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.API.Helpers.Mapper.Models
{
    public class TeamResponse
    {
        public string Name { get; set; }
        public List<PublicUserResponse> Users { get; set; }
        public List<GroupResponse> Groups { get; set; }
        public List<ProjectResponse> Projects { get; set; }

    }
}

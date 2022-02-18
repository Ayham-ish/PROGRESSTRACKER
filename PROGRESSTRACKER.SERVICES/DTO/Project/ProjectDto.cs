using PROGRESSTRACKER.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.SERVICES.DTO.Project
{
    public class ProjectDto
    {
        public string Name { get; set; }
        public int? ClientId { get; set; }
        public double Progress { get; set; }
        
    }
}

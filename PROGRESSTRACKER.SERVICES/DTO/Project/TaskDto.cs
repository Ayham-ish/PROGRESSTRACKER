using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.SERVICES.DTO.Project
{
    public class TaskDto
    {
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public int? UserId { get; set; }
    }
}

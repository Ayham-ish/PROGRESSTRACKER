using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.ENTITIES
{
    public class DailyReport : BaseEntity
    {
        public string Description { get; set; }
        
        public Work Work { get; set; }
        public int WorkId { get; set; }

    }
}

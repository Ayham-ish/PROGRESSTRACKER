using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.ENTITIES
{
    public class CustomerRequest : BaseEntity
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
    }
}

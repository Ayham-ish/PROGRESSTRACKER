using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.ENTITIES
{
    public class UserRelation : BaseEntity
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public Group Group { get; set; }
        public int GroupId { get; set; }
        public Team Team { get; set; }
        public int? TeamId { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.ENTITIES
{
    public class Admin : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DeviceToken { get; set; }
        public string AccessToken { get; set; }
        public DateTime LastLogin { get; set; }
    }
}

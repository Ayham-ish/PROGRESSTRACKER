using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.API.Helpers.Mapper.Models
{
    public class UserResponseModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }
        public string ApplicationId { get; set; }
        public virtual List<GroupResponse> Groups { get; set; }
        public virtual List<UserTeamResponse> Teams { get; set; }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.SERVICES.DTO.Auth.User
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int GenderId { get; set; }
        public int UserTypeId { get; set; }
        public string DeviceToken { get; set; }
        public string AccessToken { get; set; }
        public string ApplicationId { get; set; }
        
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace PROGRESSTRACKER.ENTITIES
{
    public class User : BaseEntity
    {
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public int GenderId { get; set; }
        public string Avatar { get; set; }
        //public List<Group> Groups { get; set; }
        //public List<Project> Projects { get; set; }
        //public List<Work> WorkList { get; set; }
        public UserType UserType { get; set; }
        public int UserTypeId { get; set; }
        public string DeviceToken { get; set; }
        public string AccessToken { get; set; }
        public string ApplicationId { get; set; }
        public bool IsBlocked { get; set; } = false;
        public bool IsOnline { get; set; } = false;
        public string Platform { get; set; }
        public DateTime LastLogin { get; set; }
        
    }
}
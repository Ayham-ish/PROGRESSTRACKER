using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.API.Helpers.Mapper.Models
{
    public class TimeTrackerResponse
    {
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime StartPoint { get; set; }
        public DateTime EndPoint { get; set; }
        public bool IsActive { get; set; }
        public List<TagResponse> Tags { get; set; }
        public ProjectNameResponse Project { get; set; }
    }
}

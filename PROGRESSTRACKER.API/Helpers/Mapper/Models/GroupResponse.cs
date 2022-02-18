using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.API.Helpers.Mapper.Models
{
    public class GroupResponse
    {
        public string Name { get; set; }
        public List<UserResponseModel> Members { get; set; }
    }
}

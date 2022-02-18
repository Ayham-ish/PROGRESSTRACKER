using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.API.Helpers.Mapper.Models
{
    public class CustomerResponse
    {
        public PublicUserResponse User { get; set; }
        public string Message { get; set; }
    }
}

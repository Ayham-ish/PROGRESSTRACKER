using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.API.Helpers.Response
{
    public class ResponseModel<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string Response { get; set; }
        public List<T> Result { get; set; }
    }
}

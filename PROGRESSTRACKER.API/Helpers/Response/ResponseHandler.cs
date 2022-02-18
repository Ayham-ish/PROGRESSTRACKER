using PROGRESSTRACKER.API.Helpers.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.API.Helpers.Return
{
    public static class ResponseHandler
    {
        public static ResponseModel<T> SetResponse<T>(this string text, int code, T obj)
        {
            var result = new List<T>();

            if (obj.GetType().GetProperties().Any())
                result.Add(obj);

            return new ResponseModel<T> { Message = text, Code = code, Response = "", Result = result };
        }

        public static ResponseModel<T> SetResponse<T>(this string text, int code, List<T> obj)
        {
            var result = new List<T>();

            if (obj.GetType().GetProperties().Any())
                result = obj;

            return new ResponseModel<T> { Message = text, Code = code, Response = "", Result = result };
        }

        public static ResponseModel<T> SetResponse<T>(this string text, int code, string response, T obj)
        {
            var result = new List<T>();

            if (obj.GetType().GetProperties().Any())
                result.Add(obj);

            return new ResponseModel<T> { Message = text, Code = code, Response = response, Result = result };
        }

        public static ResponseModel<T> SetResponse<T>(this string text, int code, string response, List<T> obj)
        {
            var result = new List<T>();

            if (obj.GetType().GetProperties().Any())
                result = obj;

            return new ResponseModel<T> { Message = text, Code = code, Response = response, Result = result };
        }
    }
}

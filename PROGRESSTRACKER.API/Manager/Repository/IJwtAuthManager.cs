using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.API.Manager.Repository
{
    public interface IJwtAuthManager
    {
        Claim[] GenerateClaims(string userId, string fullName, string email);
        string RetrieveToken(string authorization);
        string Create(Claim[] claims);
        public string Read(string token);
        //object GenerateClaims(string v, string email);
    }
}

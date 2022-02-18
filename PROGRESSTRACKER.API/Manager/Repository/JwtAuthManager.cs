using Microsoft.IdentityModel.Tokens;
using PROGRESSTRACKER.CONFIGURATION;
using PROGRESSTRACKER.HELPERS.Region;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.API.Manager.Repository
{
    public class JwtAuthManager : IJwtAuthManager
    {
        static string jwtKey = Settings.JwtKey;
    static string jwtExpirey = Settings.JwtExpirey;

    public string Create(Claim[] claims)
    {
        var now = RegionService.CurrentDateTime();

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = now.AddDays(Int32.Parse(jwtExpirey)),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public string Read(string token)
    {
        var stream = token;

        var handler = new JwtSecurityTokenHandler();
        var tokenS = handler.ReadToken(stream) as JwtSecurityToken;

        var userId = tokenS.Claims.FirstOrDefault(c => c.Type == "nameid")?.Value;

        if (string.IsNullOrWhiteSpace(userId))
            return null;

        return userId;
    }

    

    public string RetrieveToken(string authorization)
    {
        string token;

        if (authorization == null || string.IsNullOrWhiteSpace(authorization))
            return null;

        if (authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
        {
            token = authorization.Substring("Bearer ".Length).Trim();
        }
        else
        {
            return null;
        }

        return token;
    }

    public Claim[] GenerateClaims(string userId, string fullName, string email)
    {
        var claims = new[]
        {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, fullName),
                new Claim(ClaimTypes.Email, email)
            };

        return claims;
    }
}
}

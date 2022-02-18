using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.API
{
        public static class ServiceExtensions
        {
        
            public static void ConfigureSwagger(this IServiceCollection services)
            {
                services.AddSwaggerGen(s =>
                {
                
                    s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Place to add JWT with Bearer",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });
                    s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {{
                     new OpenApiSecurityScheme
                     {
                     Reference = new OpenApiReference
                     {
                     Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                     },
                    Name = "Bearer",
                     },
                     new List<string>()
                     }
                     });
                });
            }
        }
}

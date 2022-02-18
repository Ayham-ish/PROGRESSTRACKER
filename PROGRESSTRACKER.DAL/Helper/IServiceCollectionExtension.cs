using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PROGRESSTRACKER.CONFIGURATION;
using PROGRESSTRACKER.DAL.Implementation;
using PROGRESSTRACKER.DAL.Interface;
using PROGRESSTRACKER.DATACONTEXT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.DAL.Helper
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDataAccessLibrary(this IServiceCollection services)
        {
            services.AddDataAccessRepositories();
            return services;
        }

        private static IServiceCollection AddDataAccessRepositories(this IServiceCollection services)
        {
            services.AddDbContext<Context>(options => options.UseSqlServer(Settings.LocalConnectionString), ServiceLifetime.Transient);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
    }
}

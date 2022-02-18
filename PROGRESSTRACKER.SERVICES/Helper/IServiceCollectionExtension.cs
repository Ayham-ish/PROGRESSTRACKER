using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROGRESSTRACKER.DAL.Helper;
using PROGRESSTRACKER.SERVICES.Repositories.Interface;
using PROGRESSTRACKER.SERVICES.Repositories.Implementation;

namespace PROGRESSTRACKER.SERVICES.Helper
{
    public static class IServiceCollectionExtension
    {
        public static IConfiguration Configuration { get; set; }

        public static IServiceCollection AddServiceLibrary(this IServiceCollection services)
        {

            services.AddServiceRepositories();
            services.AddDataAccessLibrary();

            return services;
        }

        private static IServiceCollection AddServiceRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IDailyReportRepository, DailyReportRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<ITimeTrackerRepository, TimeTrackerRepository>();
            services.AddScoped<ITimeTrackerTagRelationRepository, TimeTrackerTagRelationRepository>();
            services.AddScoped<IWorkRepository, WorkRepository>();
            return services;
        }
    }
}

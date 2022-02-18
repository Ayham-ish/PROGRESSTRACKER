using Microsoft.Extensions.Configuration;
using System;

namespace PROGRESSTRACKER.CONFIGURATION
{
    public class Settings
    {
        public static IConfiguration Configuration { get; set; }
        public static string LocalConnectionString { get { return Configuration.GetSection("LocalConnectionString").Value; } }
        public static string RegionKey { get { return Configuration.GetSection("RegionKey").Value; } }
        public static string DocumentPath { get { return Configuration.GetSection("DocumentPath").Value; } }
        public static string JwtKey { get { return Configuration.GetSection("JwtKey").Value; } }
        public static string JwtExpirey { get { return Configuration.GetSection("JwtExpirey").Value; } }
        public static void Init(IConfiguration config)
        {
            Configuration = config;
        }
    }
}

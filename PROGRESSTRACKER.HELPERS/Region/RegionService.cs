using PROGRESSTRACKER.CONFIGURATION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.HELPERS.Region
{
    public static class RegionService 
    {
        static TimeZoneInfo timezone = TimeZoneInfo.FindSystemTimeZoneById(Settings.RegionKey);
        public static DateTime CurrentDateTime() 
        {
                return TimeZoneInfo.ConvertTime(DateTime.Now, timezone);
        }

        public static DateTime CurrentDate()
        {
            return TimeZoneInfo.ConvertTime(DateTime.Now, timezone).Date;
        }
        //public static DateTimeOffset Timestamp()
        //{
        //    var timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        //    return timestamp;
        //}
    }
}

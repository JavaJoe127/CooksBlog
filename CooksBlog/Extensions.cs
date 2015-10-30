namespace CooksBlog
{
    using System;
    using System.Configuration;

    public static class Extensions
    {
        public static string ToConfigLocalTime(this DateTime utcDate)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(ConfigurationManager.AppSettings["Timezone"]);
            return string.Format("{0} ({1})", 
                TimeZoneInfo.ConvertTimeFromUtc(utcDate, timeZone).ToShortDateString(), 
                ConfigurationManager.AppSettings["TimezoneAbbr"]);
        }
    }
}
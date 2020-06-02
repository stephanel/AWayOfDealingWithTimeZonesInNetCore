using DealingWithTimezonesInMvcCore.Services;
using System;

namespace DealingWithTimezonesInMvcCore.Infrastructure
{
    /// <summary>  
    /// User's culture information.  
    /// </summary>
    public class UserCultureInfo
    {
        private readonly ITimeService _timeService;

        public TimeZoneInfo TimeZone { get; private set; }

        public UserCultureInfo(ITimeService timeService)
        {
            _timeService = timeService;

            // TODO: need to through DB context
            TimeZone = TimeZoneInfo.FindSystemTimeZoneById("Hawaiian Standard Time");
            DateTimeFormat = "M/d/yyyy h:m:ss tt";
        }

        public string DateTimeFormat { get; private set; }

        /// <summary>  
        /// Gets the user local time.  
        /// </summary>  
        /// <returns></returns>  
        public DateTime GetUserLocalTime()
        {
            return TimeZoneInfo.ConvertTime(_timeService.Now, TimeZone);
        }

        /// <summary>  
        /// Gets the UTC time.  
        /// </summary>  
        /// <param name="datetime">The datetime.</param>  
        /// <returns>Get universal date time based on User's Timezone</returns>  
        public DateTime GetUtcTime(DateTime datetime)
        {
            return TimeZoneInfo.ConvertTime(datetime, TimeZone).ToUniversalTime();
        }
    }
}

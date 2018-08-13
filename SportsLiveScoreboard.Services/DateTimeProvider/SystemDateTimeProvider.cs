using System;

namespace SportsLiveScoreboard.Services.DateTimeProvider
{
    public class SystemDateTimeProvider:IDateTimeProvider
    {
        public DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }
    }
}
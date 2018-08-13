using System;

namespace SportsLiveScoreboard.Services.DateTimeProvider
{
    public interface IDateTimeProvider
    {
        DateTime GetCurrentDateTime();
    }
}
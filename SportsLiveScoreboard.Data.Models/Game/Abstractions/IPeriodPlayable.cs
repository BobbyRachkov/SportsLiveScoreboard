namespace SportsLiveScoreboard.Data.Models.Game.Abstractions
{
    public interface IPeriodPlayable
    {
        int PeriodNumber { get; set; }
        bool IsPeriodPlayable { get; set; }
    }
}
using SportsLiveScoreboard.Data.Models.Abstraction;

namespace SportsLiveScoreboard.Data.Models.Game
{
    public class GameSettings:EntityBase<int>
    {
        public bool IsPlayedForTime { get; set; }
        public bool IsGamePlayable { get; set; }
        public int MinGamesCount { get; set; }
        public bool IsPeriodPlayable { get; set; }
        public int MinPeriodNumber { get; set; }
        public bool IsSetPlayable { get; set; }
        public int MinSetsCount { get; set; }
        public int MinScore { get; set; }
    }
}
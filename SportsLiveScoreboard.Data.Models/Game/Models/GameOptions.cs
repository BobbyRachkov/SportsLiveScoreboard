using System.Collections.Generic;
using SportsLiveScoreboard.Data.Models.Abstraction;
using SportsLiveScoreboard.Data.Models.Game.Abstractions;

namespace SportsLiveScoreboard.Data.Models.Game.Models
{
    public class GameOptions:EntityBase<int>, IGamePlayable, IPeriodPlayable, ISetPlayable
    {
        public bool IsGamePlayable { get; set; }
        public List<Score> Games { get; set; }
        public int MaxGamesCount { get; set; }
        public bool IsPeriodPlayable { get; set; }
        public int PeriodNumber { get; set; }
        public bool IsSetPlayable { get; set; }
        public List<Score> Sets { get; set; }
        public int MaxSetsCount { get; set; }
    }
}
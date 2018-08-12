using System.Collections.Generic;
using SportsLiveScoreboard.Data.Models.Abstraction;
using SportsLiveScoreboard.Data.Models.Game.Abstractions;
using SportsLiveScoreboard.Extensions;

namespace SportsLiveScoreboard.Data.Models.Game.Models
{
    public class Match : EntityBase<string>,IGamePlayable,IPeriodPlayable,ISetPlayable
    {
        public Match()
        {
            Games.Init();
            Sets.Init();
        }
        public int Competitor1Id { get; set; }
        public Competitor Competitor1 { get; set; }
        public int Competitor2Id { get; set; }
        public Competitor Competitor2 { get; set; }
        public Score Points { get; set; }
        public bool IsPlayedForTime { get; set; }
        public List<Score> Games { get; set; }
        public int MaxGamesCount { get; set; }
        public bool IsGamePlayable { get; set; }
        public List<Score> Sets { get; set; }
        public int MaxSetsCount { get; set; }
        public bool IsSetPlayable { get; set; }
        public int PeriodNumber { get; set; }
        public bool IsPeriodPlayable { get; set; }

        public MatchStatus Status { get; set; }
        public Competitor Winner { get; set; }
        public Competitor Loser { get; set; }
    }
}
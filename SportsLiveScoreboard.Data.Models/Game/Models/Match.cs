using System;
using System.Collections.Generic;
using SportsLiveScoreboard.Data.Models.Abstraction;
using SportsLiveScoreboard.Data.Models.Game.Abstractions;
using SportsLiveScoreboard.Extensions;

namespace SportsLiveScoreboard.Data.Models.Game.Models
{
    public class Match : EntityBase<string>
    {
        public Match()
        {
        }

        public int Competitor1Id { get; set; }
        public Competitor Competitor1 { get; set; }
        public int Competitor2Id { get; set; }
        public Competitor Competitor2 { get; set; }
        public Score Points { get; set; }
        public bool IsPlayedForTime { get; set; }
        public GameOptions Options { get; set; }

        public DateTime ScheduledStartTime { get; set; }
        public DateTime ActualStartTime { get; set; }

        public MatchStatus Status { get; set; }
        public Competitor Winner { get; set; }
        public Competitor Loser { get; set; }
    }
}
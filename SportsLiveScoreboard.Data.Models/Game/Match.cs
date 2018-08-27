using System;
using System.ComponentModel.DataAnnotations.Schema;
using SportsLiveScoreboard.Data.Models.Abstraction;
using SportsLiveScoreboard.Extensions;

namespace SportsLiveScoreboard.Data.Models.Game
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

        public int ScoreInfoId { get; set; }
        public GameScoreInfo ScoreInfo { get; set; }

        public int GameSettingsId { get; set; }
        public GameSettings Settings { get; set; }

        public DateTime ScheduledStartTime { get; set; }
        public DateTime ActualStartTime { get; set; }

        public MatchStatus Status { get; set; }
        public WinnerIndex WinnerIndex { get; set; }
        [NotMapped]
        public Competitor Winner
        {
            get
            {
                if (WinnerIndex == WinnerIndex.None)
                {
                    return null;
                }

                return WinnerIndex == WinnerIndex.Competitor1 ? Competitor1 : Competitor2;
            }
            set
            {
                if (Competitor1.IsNull() || Competitor2.IsNull())
                {
                    string paramName = Competitor1.IsNull() ? nameof(Competitor1) : nameof(Competitor2);
                    throw new ArgumentNullException(paramName);
                }

                if (value.Id == Competitor1.Id)
                {
                    WinnerIndex = WinnerIndex.Competitor1;
                }
                else if (value.Id == Competitor2.Id)
                {
                    WinnerIndex = WinnerIndex.Competitor2;
                }
                else
                {
                    throw new ArgumentException("No such competitor in this match!");
                }
            }
        }
        [NotMapped]
        public Competitor Loser
        {
            get
            {
                if (WinnerIndex == WinnerIndex.None)
                {
                    return null;
                }

                return WinnerIndex == WinnerIndex.Competitor1 ? Competitor2 : Competitor1;
            }
            set
            {
                if (value.Id == Competitor1.Id)
                {
                    WinnerIndex = WinnerIndex.Competitor2;
                }
                else if (value.Id == Competitor2.Id)
                {
                    WinnerIndex = WinnerIndex.Competitor1;
                }
                else
                {
                    throw new ArgumentException("No such competitor in this match!");
                }
            }
        }

        public int RoomId { get; set; }
        public GameRoom Room { get; set; }

        public int TypeId { get; set; }
        public SportType Type { get; set; }
    }
}
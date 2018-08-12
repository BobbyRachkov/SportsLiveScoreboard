using SportsLiveScoreboard.Data.Models.Abstraction;

namespace SportsLiveScoreboard.Data.Models.Game.Models
{
    public class Score : EntityBase<int>
    {
        public int SequentialNumber { get; set; }
        public int Competitor1 { get; set; }
        public int Competitor2 { get; set; }
    }
}
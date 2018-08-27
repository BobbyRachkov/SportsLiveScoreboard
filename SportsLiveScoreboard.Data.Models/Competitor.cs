using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using SportsLiveScoreboard.Data.Models.Abstraction;
using SportsLiveScoreboard.Data.Models.Game;
using SportsLiveScoreboard.Extensions;

namespace SportsLiveScoreboard.Data.Models
{
    public class Competitor : EntityBase<int>
    {
        public Competitor()
        {
        }

        [Required]
        public string Name { get; set; }

        public int RoomId { get; set; }
        public GameRoom Room { get; set; }

        [NotMapped]
        public IEnumerable<Match> Wins => AllMatches.Where(x => x.Winner.Id == Id);
        [NotMapped]
        public IEnumerable<Match> Losses => AllMatches.Where(x => x.Winner.Id == Id);

        public List<Match> MatchesAsCompetitor1 { get; set; }
        public List<Match> MatchesAsCompetitor2 { get; set; }
        [NotMapped]
        public IEnumerable<Match> AllMatches => MatchesAsCompetitor1.Concat(MatchesAsCompetitor2);

        public bool IsComputedPerson { get; set; }
        public bool IsTheWinnerOfMatch { get; set; }
        public string CompetitorFromMatchId { get; set; }
        public Match CompetitorFromMatch { get; set; }
    }
}
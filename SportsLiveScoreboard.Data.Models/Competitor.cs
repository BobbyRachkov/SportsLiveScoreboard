using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using SportsLiveScoreboard.Data.Models.Abstraction;
using SportsLiveScoreboard.Data.Models.Game.Models;
using SportsLiveScoreboard.Extensions;

namespace SportsLiveScoreboard.Data.Models
{
    public class Competitor : EntityBase<int>
    {
        public Competitor()
        {
            Wins.Init();
            Losses.Init();
        }
        [Required]
        public string Name { get; set; }
        public GameRoom Room { get; set; }
        public List<Match> Wins { get; set; }
        public List<Match> Losses { get; set; }

        public List<Match> MatchesAsCompetitor1 { get; set; }
        public List<Match> MatchesAsCompetitor2 { get; set; }
        [NotMapped]
        public IEnumerable<Match> AllMatches => MatchesAsCompetitor1.Concat(MatchesAsCompetitor2);

        public bool IsActualPerson { get; set; }
        public bool IsTheWinnerOfMatch { get; set; }
        public string CompetitorFromMatchId { get; set; }
        public Match CompetitorFromMatch { get; set; }
    }
}
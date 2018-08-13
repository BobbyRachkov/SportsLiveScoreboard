using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SportsLiveScoreboard.Data.Models.Abstraction;
using SportsLiveScoreboard.Extensions;

namespace SportsLiveScoreboard.Data.Models.Game.Models
{
    public class GameRoom : EntityBase<int>
    {
        public GameRoom()
        {
            Matches = Matches.Init();
            Competitors = Competitors.Init();
        }

        [Required, StringLength(50, MinimumLength = 3)]
        public string SportName { get; set; }

        public Event Event { get; set; }
        public List<Match> Matches { get; set; }
        public List<Competitor> Competitors { get; set; }
        public GameOptions GameOptions { get; set; }
    }
}
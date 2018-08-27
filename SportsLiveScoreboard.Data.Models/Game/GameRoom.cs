using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SportsLiveScoreboard.Data.Models.Abstraction;
using SportsLiveScoreboard.Extensions;

namespace SportsLiveScoreboard.Data.Models.Game
{
    public class GameRoom : EntityBase<int>
    {
        public GameRoom()
        {
            Matches = Matches.Init();
            Competitors = Competitors.Init();
        }

        [Required, StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public string EventId { get; set; }
        [Required]
        public Event Event { get; set; }
        public List<Match> Matches { get; set; }
        public List<Competitor> Competitors { get; set; }
        public int GameSettingsId { get; set; }
        public GameSettings GameSettings { get; set; }

        public int SportTypeId { get; set; }
        public SportType SportType { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SportsLiveScoreboard.Data.Models.Abstraction;

namespace SportsLiveScoreboard.Data.Models.Game
{
    public class GameScoreInfo:EntityBase<int>
    {
        [Required]
        public Score Points { get; set; }
        public List<Score> Games { get; set; }
        public List<Score> Sets { get; set; }
    }
}
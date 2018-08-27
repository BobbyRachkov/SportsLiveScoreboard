using System.ComponentModel.DataAnnotations;
using SportsLiveScoreboard.Data.Models.Abstraction;

namespace SportsLiveScoreboard.Data.Models.Game
{
    public class SportType : EntityBase<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
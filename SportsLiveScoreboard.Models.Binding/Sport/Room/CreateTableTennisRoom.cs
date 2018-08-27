using System.ComponentModel.DataAnnotations;

namespace SportsLiveScoreboard.Models.BindingModels.Sport.Room
{
    public class CreateTableTennisRoom:CreateRoomBase
    {
        [Required(ErrorMessage = "The Games field is required."), Range(1, 50, ErrorMessage = "The minimum games should not exceed {2}")]
        public int MinGames { get; set; }

        [Required(ErrorMessage = "The Games field is required."), Range(1, 50, ErrorMessage = "The minimum points should not exceed {2}")]
        public int PointsPerGame { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SportsLiveScoreboard.Models.BindingModels.Sport.Room
{
    public class CreateBasketballRoom:CreateRoomBase
    {
        [Required, Range(1, 20,ErrorMessage = "The minimum periods should not exceed {2}")]
        public int MinPeriods { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SportsLiveScoreboard.Models.BindingModels.Sport.Room
{
    public abstract class CreateRoomBase
    {
        public string EventId { get; set; }

        [Required, StringLength(50, MinimumLength = 3), Remote("IsRoomNameFree", "Room", "Sport", HttpMethod = "POST", AdditionalFields = "EventId")]
        public string Name { get; set; }
    }
}
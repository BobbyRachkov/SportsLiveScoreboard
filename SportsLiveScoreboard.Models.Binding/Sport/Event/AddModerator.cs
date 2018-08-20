using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SportsLiveScoreboard.Models.BindingModels.Sport.Event
{
    public class AddModerator
    {
        [Required]
        [Remote("CanAddModerator", "Event", "Sport", HttpMethod = "POST",AdditionalFields = "EventId")]
        public string Username { get; set; }

        public string EventId { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SportsLiveScoreboard.Models.BindingModels.Sport.Event
{
    public class TransferOwnership
    {
        [Required]
        [Remote("IsUsernamePresent","Event","Sport",HttpMethod = "POST")]
        public string Username { get; set; }

        public string EventId { get; set; }
    }
}
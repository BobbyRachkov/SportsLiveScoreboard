using System.ComponentModel.DataAnnotations;
using SportsLiveScoreboard.Data.Models.Identity;

namespace SportsLiveScoreboard.Data.Models
{
    public class UserEvents
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string EventId { get; set; }
        public Event Event { get; set; }
    }
}
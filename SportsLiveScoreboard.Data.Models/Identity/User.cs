using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SportsLiveScoreboard.Data.Models.Identity
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            
        }

        public List<Event> Events { get; set; }
        public List<UserEvents> EventsInModeration { get; set; }
    }
}
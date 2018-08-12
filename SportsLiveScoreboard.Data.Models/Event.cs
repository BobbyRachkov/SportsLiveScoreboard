using System.Collections.Generic;
using SportsLiveScoreboard.Data.Models.Abstraction;
using SportsLiveScoreboard.Data.Models.Game.Models;
using SportsLiveScoreboard.Data.Models.Identity;
using SportsLiveScoreboard.Extensions;

namespace SportsLiveScoreboard.Data.Models
{
    public class Event:EntityBase<string>
    {
        public Event()
        {
            Moderators.Init();
            Rooms.Init();
        }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public string OwnerId { get; set; }
        public User Owner { get; set; }
        public List<UserEvents> Moderators { get; set; }
        public List<GameRoom> Rooms { get; set; }
    }
}
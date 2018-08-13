using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SportsLiveScoreboard.Data.Models.Abstraction;
using SportsLiveScoreboard.Data.Models.Game.Models;
using SportsLiveScoreboard.Data.Models.Identity;
using SportsLiveScoreboard.Extensions;

namespace SportsLiveScoreboard.Data.Models
{
    public class Event : EntityBase<string>
    {
        public Event()
        {
            Moderators = Moderators.Init();
            Rooms = Rooms.Init();
        }

        public string Name { get; set; }
        public string Code { get; set; }
        [NotMapped]
        public bool IsActive => !string.IsNullOrWhiteSpace(Code);
        public string OwnerId { get; set; }
        public User Owner { get; set; }
        public List<UserEvents> Moderators { get; set; }
        public List<GameRoom> Rooms { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
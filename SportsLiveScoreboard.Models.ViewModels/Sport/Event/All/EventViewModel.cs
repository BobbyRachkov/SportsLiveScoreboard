using System;
using System.Linq.Expressions;

namespace SportsLiveScoreboard.Models.ViewModels.Sport.Event.All
{
    public class EventViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int GameRoomCount { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }

        public static Func<Data.Models.Event, EventViewModel> FromEvent =>
        x => new EventViewModel
        {
            Id = x.Id,
            Name = x.Name,
            Code = x.Code,
            GameRoomCount = x.Rooms.Count,
            DateCreated = x.DateCreated,
            IsActive = x.IsActive
        };
    }
}
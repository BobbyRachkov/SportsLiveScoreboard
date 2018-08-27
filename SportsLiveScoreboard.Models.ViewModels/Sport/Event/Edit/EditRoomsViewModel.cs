using System;
using System.Collections.Generic;

namespace SportsLiveScoreboard.Models.ViewModels.Sport.Event.Edit
{
    public class EditRoomsViewModel
    {
        public string EventId { get; set; }
        public List<GameRoomViewModel> GameRooms{ get; set; }
    }
}
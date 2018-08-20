using System.Collections.Generic;
using SportsLiveScoreboard.Extensions;

namespace SportsLiveScoreboard.Models.ViewModels.Sport.Event.Edit
{
    public class ModeratorsViewModel
    {
        public ModeratorsViewModel()
        {
            Moderators = Moderators.Init();
        }

        public List<ModeratorViewModel> Moderators { get; set; }
        public string EventId { get; set; }
    }
}
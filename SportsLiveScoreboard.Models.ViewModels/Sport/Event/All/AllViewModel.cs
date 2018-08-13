using System.Collections.Generic;
using SportsLiveScoreboard.Models.BindingModels.Sport.Event;

namespace SportsLiveScoreboard.Models.ViewModels.Sport.Event.All
{
    public class AllViewModel
    {
        public string Target { get; set; }
        public List<EventViewModel> Events { get; set; }
    }
}
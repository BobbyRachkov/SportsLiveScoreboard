namespace SportsLiveScoreboard.Models.ViewModels.Sport.Event.Edit
{
    public class EditViewModel
    {
        public string EventId { get; set; }
        public string Name { get; set; }
        public EditCodeViewModel EditCodeViewModel { get; set; }
        public ModeratorsViewModel ModeratorsViewModel { get; set; }
        public EditRoomsViewModel RoomsViewModel { get; set; }
    }
}
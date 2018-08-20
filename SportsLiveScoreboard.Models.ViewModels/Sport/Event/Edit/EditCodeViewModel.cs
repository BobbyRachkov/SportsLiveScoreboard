namespace SportsLiveScoreboard.Models.ViewModels.Sport.Event.Edit
{
    public class EditCodeViewModel
    {
        public string EventId { get; set; }
        public string Code { get; set; }
        public bool IsActive => !string.IsNullOrWhiteSpace(Code);
    }
}
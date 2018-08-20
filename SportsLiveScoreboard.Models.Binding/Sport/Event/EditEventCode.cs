using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SportsLiveScoreboard.Models.BindingModels.Sport.Event
{
    public class EditEventCode
    {
        [Remote("IsCodeAvailable", "Event", "Sport", HttpMethod = "POST")]
        [RegularExpression("[A-Za-z0-9]+",ErrorMessage = StringConstants.CodeRegexValidationMessage)]
        [StringLength(20, MinimumLength = 5, ErrorMessage = StringConstants.StringLengthValidationMessage)]
        public string Code { get; set; }
        public CheckboxResult ActivationType { get; set; }
        public string EventId { get; set; }
    }
}
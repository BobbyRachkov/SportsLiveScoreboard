using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SportsLiveScoreboard.Models.BindingModels.Sport.Event
{
    public class CreateEvent
    {
        [Required,StringLength(70,MinimumLength = 5,ErrorMessage = StringConstants.StringLengthValidationMessage)]
        public string Name { get; set; }
        [Remote("IsCodeAvailable","Event","Sport",HttpMethod = "POST")]
        [StringLength(20,MinimumLength = 5,ErrorMessage = StringConstants.StringLengthValidationMessage)]
        public string Code { get; set; }
        public CheckboxResult ActivationType { get; set; }
    }
}
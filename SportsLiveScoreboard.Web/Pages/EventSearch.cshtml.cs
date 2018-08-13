using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsLiveScoreboard.Services.Data;

namespace SportsLiveScoreboard.Web.Pages
{
    public class EventSearchModel : PageModel
    {
        private readonly ISportsData _data;

        public EventSearchModel(ISportsData data)
        {
            _data = data;
        }

        [BindProperty] public string EventCode { get; set; }

        public bool? Exists { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Exists = _data.Events.ExistsWithCode(EventCode);
            if (!Exists.Value)
            {
                return Page();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
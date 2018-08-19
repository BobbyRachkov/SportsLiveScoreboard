using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SportsLiveScoreboard.Web.Areas.Live.Controllers
{
    [Area(nameof(Live))]
    [AllowAnonymous]
    public class EventController : Controller
    {
        public IActionResult Index(string code)
        {
            return View((object)code);
        }
    }
}
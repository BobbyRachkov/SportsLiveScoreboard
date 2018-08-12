using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SportsLiveScoreboard.Web.Models;
using SportsLiveScoreboard.Web.Pages;
using SportsLiveScoreboard.Web.Utilities;

namespace SportsLiveScoreboard.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        public IActionResult Index()
        {
            return RedirectToPage(Utils.NameOfPage<EventSearchModel>("/"));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

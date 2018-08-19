using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsLiveScoreboard.Data.Models;
using SportsLiveScoreboard.Models.BindingModels.Sport.Event;
using SportsLiveScoreboard.Models.ViewModels.Sport.Event;
using SportsLiveScoreboard.Models.ViewModels.Sport.Event.All;
using SportsLiveScoreboard.Models.ViewModels.Sport.Event.Edit;
using SportsLiveScoreboard.Services.Data;
using SportsLiveScoreboard.Services.DateTimeProvider;
using SportsLiveScoreboard.Services.RandomCodes;

namespace SportsLiveScoreboard.Web.Areas.Sport.Controllers
{
    [Area(nameof(Sport))]
    [Authorize]
    public class EventController : Controller
    {
        private readonly ISportsData _data;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IRandomCodeProvider _randomCodeProvider;

        public EventController(ISportsData data, IDateTimeProvider dateTimeProvider,
            IRandomCodeProvider randomCodeProvider)
        {
            _data = data;
            _dateTimeProvider = dateTimeProvider;
            _randomCodeProvider = randomCodeProvider;
        }

        // GET
        public IActionResult Index()
        {
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEvent model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(All));
            }


            var user = await _data.UserManager.GetUserAsync(User);
            Event e = new Event
            {
                Name = model.Name,
                DateCreated = _dateTimeProvider.GetCurrentDateTime(),
                Owner = user
            };

            switch (model.ActivationType)
            {
                case CheckboxResult.GivenCode:
                    if (string.IsNullOrWhiteSpace(model.Code) || _data.Events.ExistsWithCode(model.Code))
                    {
                        e.Code = GenerateUniqueCode(8);
                    }
                    else
                    {
                        e.Code = model.Code.ToLower();
                    }

                    break;
                case CheckboxResult.GenerateRandom:
                    e.Code = GenerateUniqueCode(8);
                    break;
                default:
                    e.Code = "";
                    break;
            }

            await _data.Events.AddAsync(e);
            await _data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> All(string target)
        {
            AllViewModel vm = new AllViewModel {Target = target};
            var user = await _data.UserManager.GetUserAsync(User);
            vm.Events = _data
                .Events
                .Include(x => x.Rooms)
                .OrderByDescending(x => x.DateCreated)
                .GetWhere(x => x.OwnerId == user.Id)
                .Select(EventViewModel.FromEvent)
                .ToList();

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            Event e = await _data.Events.GetAsync(id);
            EditViewModel vm=new EditViewModel();
            vm.EditCodeViewModel = new EditCodeViewModel
            {
                Code = e.Code
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult IsCodeAvailable(string code)
        {
            if (_data.Events.ExistsWithCode(code))
            {
                return Json("This code is taken.");
            }
            return Json(true);
        }

        private string GenerateUniqueCode(int length)
        {
            string code;
            while (_data.Events.ExistsWithCode(code = _randomCodeProvider.GenerateCode(length)))
            {
            }

            return code;
        }
    }
}
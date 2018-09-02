using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsLiveScoreboard.Data.Models;
using SportsLiveScoreboard.Data.Models.Identity;
using SportsLiveScoreboard.Models.BindingModels.Sport.Event;
using SportsLiveScoreboard.Models.ViewModels.Sport.Event;
using SportsLiveScoreboard.Models.ViewModels.Sport.Event.All;
using SportsLiveScoreboard.Models.ViewModels.Sport.Event.Edit;
using SportsLiveScoreboard.Services.Data;
using SportsLiveScoreboard.Services.DateTimeProvider;
using SportsLiveScoreboard.Services.RandomCodes;
using SportsLiveScoreboard.Web.Architecture;

namespace SportsLiveScoreboard.Web.Areas.Sport.Controllers
{
    [Area(nameof(Sport))]
    [Authorize]
    public class EventController : SportController
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IRandomCodeProvider _randomCodeProvider;

        public EventController(ISportsData data, IDateTimeProvider dateTimeProvider,
            IRandomCodeProvider randomCodeProvider) : base(data)
        {
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


            var user = await Data.UserManager.GetUserAsync(User);
            Event e = new Event
            {
                Name = model.Name,
                DateCreated = _dateTimeProvider.GetCurrentDateTime(),
                Owner = user
            };

            switch (model.ActivationType)
            {
                case CheckboxResult.GivenCode:
                    SetCustomCode(e, model.Code);
                    break;
                case CheckboxResult.GenerateRandom:
                    e.Code = GenerateUniqueCode(8);
                    break;
                default:
                    e.Code = "";
                    break;
            }

            await Data.Events.AddAsync(e);
            await Data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> All(string target)
        {
            AllViewModel vm = new AllViewModel {Target = target};
            var user = await Data.UserManager.GetUserAsync(User);
            vm.Events = Data
                .Events
                .Include(x => x.Rooms)
                .OrderByDescending(x => x.DateCreated)
                .GetWhere(x => x.OwnerId == user.Id)
                .Select(EventViewModel.FromEvent)
                .ToList();

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id, string target)
        {
            ViewBag.Target = target;
            Event e = await Data.Events.GetByIdWithIncludedRoomsAndMatches(id);
            if (e == null)
            {
                return NotFound();
            }

            if (!await Data.ModerationManager.HasAdministrationRightsOverEvent(e, DbUser))
            {
                return Unauthorized();
            }

            EditViewModel vm = new EditViewModel
            {
                EventId = e.Id,
                Name = e.Name,
                EditCodeViewModel = new EditCodeViewModel
                {
                    EventId = e.Id,
                    Code = e.Code
                },
                ModeratorsViewModel = GetModeratorsViewModel(id),
                RoomsViewModel = new EditRoomsViewModel
                {
                    EventId = id,
                    GameRooms = e.Rooms
                        .Select(x => new GameRoomViewModel
                        {
                            Id = x.Id,
                            Name = x.Name,
                            MatchesCount = x.Matches.Count,
                            SportType = x.SportType.Name
                        })
                        .ToList()
                }
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult IsCodeAvailable(string code)
        {
            if (Data.Events.ExistsWithCode(code))
            {
                return Json("This code is taken.");
            }

            return Json(true);
        }

        [HttpPost]
        public IActionResult IsUsernamePresent(string username)
        {
            if (!Data.Users.Any(x => x.UserName == username))
            {
                return Json("No profile with such username.");
            }

            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> TransferOwnership(TransferOwnership model)
        {
            Event e = await Data.Events.Include(x => x.Owner).GetAsync(model.EventId);
            if (e == null)
            {
                return NotFound();
            }

            if (!await Data.ModerationManager.HasAdministrationRightsOverEvent(e, DbUser))
            {
                return Unauthorized();
            }

            User destinationUser = await Data.Users.GetFirstAsync(x => x.UserName == model.Username);
            if (destinationUser == null)
            {
                return NotFound();
            }

            e.Owner = destinationUser;
            await Data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> ChangeCode(EditEventCode model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Edit), new {id = model.EventId});
            }

            Event e = await Data.Events.GetAsync(model.EventId);
            if (e == null)
            {
                return NotFound();
            }

            if (!await Data.ModerationManager.HasAdministrationRightsOverEvent(e, DbUser))
            {
                return Unauthorized();
            }

            switch (model.ActivationType)
            {
                case CheckboxResult.GivenCode:
                    SetCustomCode(e, model.Code);
                    break;
                default:
                    e.Code = GenerateUniqueCode(8);
                    break;
            }

            await Data.SaveChangesAsync();
            return RedirectToAction(nameof(Edit), new {id = model.EventId});
        }

        [HttpPost]
        public async Task<IActionResult> DeactivateEvent(string id)
        {
            Event e = await Data.Events.GetAsync(id);
            if (e == null)
            {
                return NotFound();
            }

            if (!await Data.ModerationManager.HasAdministrationRightsOverEvent(e, DbUser))
            {
                return Unauthorized();
            }

            e.Code = "";
            await Data.SaveChangesAsync();
            return RedirectToAction(nameof(Edit), new {id = id});
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] string id, [FromForm] string eventName)
        {
            Event e = await Data.Events.GetAsync(id);
            if (e == null)
            {
                return NotFound();
            }

            if (!await Data.ModerationManager.HasAdministrationRightsOverEvent(e, DbUser))
            {
                return Unauthorized();
            }

            if (string.IsNullOrWhiteSpace(eventName) ||
                e.Name.ToLower().Replace(" ", "") != eventName.ToLower().Replace(" ", ""))
            {
                return RedirectToAction(nameof(Edit), new {id = id});
            }

            Data.Events.Delete(e);
            await Data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> AddModerator(AddModerator model)
        {
            Event e = await Data.Events.Include(x => x.Moderators).GetAsync(model.EventId);
            if (e == null)
            {
                return NotFound();
            }

            if (!await Data.ModerationManager.HasAdministrationRightsOverEvent(e, DbUser))
            {
                return Unauthorized();
            }

            User newModerator = await Data.Users.GetFirstAsync(x => x.UserName == model.Username);
            if (newModerator == null)
            {
                return NotFound();
            }

            e.Moderators.Add(new UserEvents {Event = e, User = newModerator});
            await Data.SaveChangesAsync();

            return RedirectToAction("Edit", new {target = "moderation", id = model.EventId});
        }

        [HttpPost]
        public async Task<IActionResult> RemoveModerator(string eventId, string userId)
        {
            Event e = await Data.Events.Include(x => x.Moderators).GetAsync(eventId);
            if (e == null)
            {
                return NotFound();
            }

            if (!await Data.ModerationManager.HasAdministrationRightsOverEvent(e, DbUser))
            {
                return Unauthorized();
            }

            UserEvents relation = e.Moderators.FirstOrDefault(x => x.UserId == userId);
            e.Moderators.Remove(relation);
            await Data.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public IActionResult CanAddModerator(string username, string eventId)
        {
            Event e = Data.Events.GetByIdWithIncludedModerators(eventId);
            if (e == null)
            {
                return NotFound();
            }

            if (username == User.Identity.Name)
            {
                return Json("You cannot add yourself as a moderator.");
            }

            if (!Data.Users.Any(x => x.UserName == username))
            {
                return Json("No profile with such username.");
            }

            if (e.Moderators.Any(x => x.User.UserName == username))
            {
                return Json("This person is already a moderator!");
            }

            return Json(true);
        }

        private ModeratorsViewModel GetModeratorsViewModel(string eventId)
        {
            Event e = Data.Events.GetByIdWithIncludedModerators(eventId);
            return new ModeratorsViewModel
            {
                EventId = eventId,
                Moderators = e.Moderators.Select(x => new ModeratorViewModel
                    {
                        Id = x.User.Id,
                        Username = x.User.UserName
                    })
                    .ToList()
            };
        }

        private void SetCustomCode(Event e, string code)
        {
            if (string.IsNullOrWhiteSpace(code) || Data.Events.ExistsWithCode(code))
            {
                e.Code = GenerateUniqueCode(8);
            }
            else
            {
                e.Code = code.ToLower();
            }
        }

        private string GenerateUniqueCode(int length)
        {
            string code;
            while (Data.Events.ExistsWithCode(code = _randomCodeProvider.GenerateCode(length)))
            {
            }

            return code;
        }
    }
}
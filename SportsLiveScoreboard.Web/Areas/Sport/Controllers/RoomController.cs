using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsLiveScoreboard.Data.Models;
using SportsLiveScoreboard.Data.Models.Game;
using SportsLiveScoreboard.Extensions;
using SportsLiveScoreboard.Models.BindingModels.Sport.Room;
using SportsLiveScoreboard.Services.Data;
using SportsLiveScoreboard.Web.Architecture;
using GameSettings = SportsLiveScoreboard.Data.Models.Game.GameSettings;

namespace SportsLiveScoreboard.Web.Areas.Sport.Controllers
{
    [Authorize]
    [Area(nameof(Sport))]
    public class RoomController : SportController
    {
        public RoomController(ISportsData data) : base(data)
        {
        }

        [HttpPost]
        public IActionResult IsRoomNameFree(string name, string eventId)
        {
            if (Data.GameRooms.Any(x => x.EventId == eventId && x.Name.ToLower() == name.ToLower()))
            {
                return Json("Choose unique game room name.");
            }

            return Json(true);
        }

        public async Task<IActionResult> DeleteRoom(int id, string eventId)
        {
            GameRoom room = await Data.GameRooms.Include(x => x.Event).GetAsync(id);
            if (room.IsNull())
            {
                return NotFound();
            }
            if (room.EventId!=eventId)
            {
                return BadRequest();
            }
            if (!IsOwnerOrAdministrator(room.Event))
            {
                return Unauthorized();
            }
            Data.GameRooms.Delete(room);
            await Data.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasketballRoom(CreateBasketballRoom model)
        {
            Event e = await Data.Events.Include(x => x.Rooms).GetAsync(model.EventId);
            if (e == null)
            {
                return NotFound();
            }
            if (!IsOwnerOrAdministrator(e))
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            GameRoom room = new GameRoom
            {
                Name = model.Name,
                SportType = await Data.SportTypes.GetByNameAsync("Basketball"),
                GameSettings = new GameSettings
                {
                    IsPlayedForTime = true,
                    IsPeriodPlayable = true,
                    MinPeriodNumber = model.MinPeriods
                }
            };
            e.Rooms.Add(room);
            await Data.SaveChangesAsync();


            return RedirectToAction("Edit", "Event", new {area = "Sport", id = model.EventId, target = "rooms"});
        }

        public async Task<IActionResult> CreateVolleyballRoom(CreateVolleyballRoom model)
        {
            Event e = await Data.Events.Include(x => x.Rooms).GetAsync(model.EventId);
            if (e == null)
            {
                return NotFound();
            }
            if (!IsOwnerOrAdministrator(e))
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            GameRoom room = new GameRoom
            {
                Name = model.Name,
                SportType = await Data.SportTypes.GetByNameAsync("Volleyball"),
                GameSettings = new GameSettings
                {
                    IsPlayedForTime = false,
                    IsGamePlayable = true,
                    MinGamesCount = model.MinGames
                }
            };
            e.Rooms.Add(room);
            await Data.SaveChangesAsync();

            return RedirectToAction("Edit", "Event", new { area = "Sport", id = model.EventId, target = "rooms" });
        }
        public async Task<IActionResult> CreateTableTennisRoom(CreateVolleyballRoom model)
        {
            Event e = await Data.Events.Include(x => x.Rooms).GetAsync(model.EventId);
            if (e == null)
            {
                return NotFound();
            }
            if (!IsOwnerOrAdministrator(e))
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            GameRoom room = new GameRoom
            {
                Name = model.Name,
                SportType = await Data.SportTypes.GetByNameAsync("Table Tennis"),
                GameSettings = new GameSettings
                {
                    IsGamePlayable = true,
                    MinGamesCount = model.MinGames,
                    IsPlayedForTime = false
                }
            };
            e.Rooms.Add(room);
            await Data.SaveChangesAsync();

            return RedirectToAction("Edit", "Event", new { area = "Sport", id = model.EventId, target = "rooms" });
        }
    }
}
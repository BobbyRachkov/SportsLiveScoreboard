using System.Linq;
using System.Threading.Tasks;
using SportsLiveScoreboard.Data.Models;
using SportsLiveScoreboard.Data.Models.Game;
using SportsLiveScoreboard.Data.Models.Identity;
using SportsLiveScoreboard.Extensions;
using SportsLiveScoreboard.Services.Data.Contracts;

namespace SportsLiveScoreboard.Services.Data.Services
{
    public class ModerationManager : IModerationManager
    { 
        private readonly ISportsData _data;

        public ModerationManager(ISportsData data)
        {
            _data = data;
        }

        public async Task<bool> HasAdministrationRightsOverEvent(Event evnt, User user)
        {
            if (evnt.IsNull())
            {
                return false;
            }

            return evnt.OwnerId == user.Id ||
                   await _data.UserManager.IsInRoleAsync(user, nameof(RoleType.Administrator));
        }

        public async Task<bool> HasAdministrationRightsOverEvent(string eventId, User user)
        {
            return await HasAdministrationRightsOverEvent(await _data.Events.GetAsync(eventId), user);
        }

        public async Task<bool> HasAdministrationRightsOverRoom(GameRoom room, User user)
        {
            if (room.IsNull())
            {
                return false;
            }

            return room.Event.OwnerId == user.Id ||
                   await _data.UserManager.IsInRoleAsync(user, nameof(RoleType.Administrator));
        }

        public async Task<bool> HasAdministrationRightsOverRoom(int roomId, User user)
        {
            return await HasAdministrationRightsOverRoom(await _data.GameRooms.Include(x => x.Event).GetAsync(roomId),
                user);
        }

        public async Task<bool> HasAdministrationRightsOverMatch(Match match, User user)
        {
            if (match.IsNull())
            {
                return false;
            }

            return match.Room.Event.OwnerId == user.Id ||
                   await _data.UserManager.IsInRoleAsync(user, nameof(RoleType.Administrator));
        }

        public async Task<bool> HasAdministrationRightsOverMatch(string matchId, User user)
        {
            return await HasAdministrationRightsOverMatch(
                await _data.Matches.GetMatchWithIncludedRoomEventModeratorsJoinObject(matchId),
                user);
        }

        public async Task<bool> HasModerationRightsOverEvent(Event evnt, User user)
        {
            if (evnt.IsNull())
            {
                return false;
            }

            return evnt.Moderators.Any(x => x.UserId.ToLower() == user.Id.ToLower()) ||
                   await HasAdministrationRightsOverEvent(evnt, user);
        }

        public async Task<bool> HasModerationRightsOverEvent(string eventId, User user)
        {
            return await HasModerationRightsOverEvent(await _data.Events.Include(x => x.Moderators).GetAsync(eventId),
                user);
        }

        public async Task<bool> HasModerationRightsOverRoom(GameRoom room, User user)
        {
            if (room.IsNull())
            {
                return false;
            }

            return room.Event.Moderators.Any(x => x.UserId.ToLower() == user.Id.ToLower()) ||
                   await HasAdministrationRightsOverRoom(room, user);
        }

        public async Task<bool> HasModerationRightsOverRoom(int roomId, User user)
        {
            return await HasModerationRightsOverRoom(
                await _data.GameRooms.GetByIdWithIncludedEventAndModeratorsJoinObject(roomId), user);
        }

        public async Task<bool> HasModerationRightsOverMatch(Match match, User user)
        {
            if (match.IsNull())
            {
                return false;
            }

            return match.Room.Event.Moderators.Any(x => x.UserId.ToLower() == user.Id.ToLower()) ||
                   await HasAdministrationRightsOverMatch(match, user);
        }

        public async Task<bool> HasModerationRightsOverMatch(string matchId, User user)
        {
            return await HasModerationRightsOverMatch(
                await _data.Matches.GetMatchWithIncludedRoomEventModeratorsJoinObject(matchId), user);
        }
    }
}
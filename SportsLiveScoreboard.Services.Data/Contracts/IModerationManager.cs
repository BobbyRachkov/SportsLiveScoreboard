using System.Threading.Tasks;
using SportsLiveScoreboard.Data.Models;
using SportsLiveScoreboard.Data.Models.Game;
using SportsLiveScoreboard.Data.Models.Identity;

namespace SportsLiveScoreboard.Services.Data.Contracts
{
    public interface IModerationManager
    {
        Task<bool> HasAdministrationRightsOverEvent(Event evnt, User user);
        Task<bool> HasAdministrationRightsOverEvent(string eventId, User user);
        Task<bool> HasAdministrationRightsOverMatch(Match match, User user);
        Task<bool> HasAdministrationRightsOverMatch(string matchId, User user);
        Task<bool> HasAdministrationRightsOverRoom(GameRoom room, User user);
        Task<bool> HasAdministrationRightsOverRoom(int roomId, User user);
        Task<bool> HasModerationRightsOverEvent(Event evnt, User user);
        Task<bool> HasModerationRightsOverEvent(string eventId, User user);
        Task<bool> HasModerationRightsOverMatch(Match match, User user);
        Task<bool> HasModerationRightsOverMatch(string matchId, User user);
        Task<bool> HasModerationRightsOverRoom(GameRoom room, User user);
        Task<bool> HasModerationRightsOverRoom(int roomId, User user);
    }
}
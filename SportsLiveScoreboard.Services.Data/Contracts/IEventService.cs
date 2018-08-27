using System.Threading.Tasks;
using SportsLiveScoreboard.Data.Models;
using SportsLiveScoreboard.Services.Data.Abstraction;
using SportsLiveScoreboard.Services.Data.Services;

namespace SportsLiveScoreboard.Services.Data.Contracts
{
    public interface IEventService : IDataService<Event, string, EventService>
    {
        bool ExistsWithCode(string code);
        Event GetByIdWithIncludedModerators(string id);
        Task<Event> GetByIdWithIncludedRoomsAndMatches(string id);
    }
}
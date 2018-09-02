using SportsLiveScoreboard.Data.Models.Game;
using SportsLiveScoreboard.Services.Data.Abstraction;
using System.Threading.Tasks;

namespace SportsLiveScoreboard.Services.Data.Services
{
    public interface IMatchService:IDataService<Match,string,MatchService>
    {
        Task<Match> GetMatchWithIncludedRoomEventModeratorsJoinObject(string id);
        Task<Match> GetMatchWithIncludedRoomEventModeratorsFullObject(string id);
    }
}
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsLiveScoreboard.Data.Models.Game;
using SportsLiveScoreboard.Services.Data.Abstraction;

namespace SportsLiveScoreboard.Services.Data.Services
{
    public class MatchService:DataServiceBase<Match,string,MatchService>,IMatchService
    {
        public MatchService(SportsData data) : base(data)
        {
        }

        public async Task<Match> GetMatchWithIncludedRoomEventModeratorsJoinObject(string id)
        {
            return await CurrentDbSet
                .Include(x => x.Room)
                .ThenInclude(x => x.Event)
                .ThenInclude(x => x.Moderators)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Match> GetMatchWithIncludedRoomEventModeratorsFullObject(string id)
        {
            return await CurrentDbSet
                .Include(x => x.Room)
                .ThenInclude(x => x.Event)
                .ThenInclude(x => x.Moderators)
                .ThenInclude(x=>x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsLiveScoreboard.Data.Models.Game;
using SportsLiveScoreboard.Services.Data.Abstraction;
using SportsLiveScoreboard.Services.Data.Contracts;

namespace SportsLiveScoreboard.Services.Data.Services
{
    public class GameRoomService : DataServiceBase<GameRoom, int, GameRoomService>,IGameRoomService
    {
        public GameRoomService(SportsData data) : base(data)
        {
        }


        public async Task<bool> ExistsGameWithNameAsync(string name)
        {
            return await CurrentDbSet.AnyAsync(x => x.Name.ToLower() == name.ToLower());
        }

        public async Task<GameRoom> GetByIdWithIncludedEventAndModeratorsJoinObject(int id)
        {
            return await CurrentDbSet
                .Include(x => x.Event)
                .ThenInclude(x => x.Moderators)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<GameRoom> GetByIdWithIncludedEventAndModeratorsFullObject(int id)
        {
            return await CurrentDbSet
                .Include(x => x.Event)
                .ThenInclude(x => x.Moderators)
                .ThenInclude(x=>x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override void Delete(GameRoom entity)
        {
            //entity = Data
            //    .Context
            //    .GameRooms
            //    .Include(x=>x.)
            //    .Single(x => x.Id == entity.Id);
            //Data.Context.GameSettings.Remove(entity.GameSettings);
            //Data.Context.Matches.RemoveRange(entity.Matches);
            //Data.Context.Competitors.RemoveRange(entity.Competitors);
            base.Delete(entity);
        }
    }
}
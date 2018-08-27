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
    }
}
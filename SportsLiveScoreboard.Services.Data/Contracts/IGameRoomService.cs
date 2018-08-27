using System.Threading.Tasks;
using SportsLiveScoreboard.Data.Models.Game;
using SportsLiveScoreboard.Services.Data.Abstraction;
using SportsLiveScoreboard.Services.Data.Services;

namespace SportsLiveScoreboard.Services.Data.Contracts
{
    public interface IGameRoomService:IDataService<GameRoom,int,GameRoomService>
    {
        Task<bool> ExistsGameWithNameAsync(string name);
    }
}
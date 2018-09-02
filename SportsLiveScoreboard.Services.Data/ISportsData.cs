using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SportsLiveScoreboard.Data.Models.Identity;
using SportsLiveScoreboard.Services.Data.Contracts;
using SportsLiveScoreboard.Services.Data.Services;

namespace SportsLiveScoreboard.Services.Data
{
    public interface ISportsData
    {
        IEventService Events { get; }
        IUserService Users { get; }
        ISportTypeService SportTypes { get; }
        IGameRoomService GameRooms { get; }
        IMatchService Matches { get; }

        RoleManager<Role> RoleManager { get; }
        SignInManager<User> SignInManager { get; }
        UserManager<User> UserManager { get; }
        IModerationManager ModerationManager { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
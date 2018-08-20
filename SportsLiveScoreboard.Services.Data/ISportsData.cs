using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SportsLiveScoreboard.Data.Models.Identity;
using SportsLiveScoreboard.Services.Data.Contracts;

namespace SportsLiveScoreboard.Services.Data
{
    public interface ISportsData
    {
        IEventService Events { get; }
        IUserService Users { get; }
        RoleManager<Role> RoleManager { get; }
        SignInManager<User> SignInManager { get; }
        UserManager<User> UserManager { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
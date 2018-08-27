using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SportsLiveScoreboard.Data;
using SportsLiveScoreboard.Data.Models.Identity;
using SportsLiveScoreboard.Extensions;
using SportsLiveScoreboard.Services.Data.Contracts;
using SportsLiveScoreboard.Services.Data.Services;

namespace SportsLiveScoreboard.Services.Data
{
    public class SportsData : ISportsData
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;

        private Lazy<IEventService> eventService;
        private Lazy<IUserService> userService;
        private Lazy<ISportTypeService> sportTypeService;
        private Lazy<IGameRoomService> gameRoomService;

        public SportsData(SportsDbContext dbContext, UserManager<User> userManager, RoleManager<Role> roleManager,
            SignInManager<User> signInManager)
        {
            Context = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;

            eventService = eventService.InitLazy(new EventService(this));
            userService = userService.InitLazy(new UserService(this));
            sportTypeService = sportTypeService.InitLazy(new SportTypeService(this));
            gameRoomService = gameRoomService.InitLazy(new GameRoomService(this));
        }
        internal SportsDbContext Context { get; }

        public UserManager<User> UserManager => _userManager;
        public RoleManager<Role> RoleManager => _roleManager;
        public SignInManager<User> SignInManager => _signInManager;
        public IEventService Events => eventService.Value;
        public IUserService Users => userService.Value;
        public ISportTypeService SportTypes => sportTypeService.Value;
        public IGameRoomService GameRooms => gameRoomService.Value;


        public void SaveChanges()
        {
            Context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
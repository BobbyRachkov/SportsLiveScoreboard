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
        private readonly Lazy<IEventService> _eventService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<ISportTypeService> _sportTypeService;
        private readonly Lazy<IGameRoomService> _gameRoomService;
        private readonly Lazy<IMatchService> _matchService;
        private readonly Lazy<IModerationManager> _moderationManager;


        public SportsData(SportsDbContext dbContext, UserManager<User> userManager, RoleManager<Role> roleManager,
            SignInManager<User> signInManager)
        {
            Context = dbContext;
            UserManager = userManager;
            RoleManager = roleManager;
            SignInManager = signInManager;

            _eventService = _eventService.InitLazy(new EventService(this));
            _userService = _userService.InitLazy(new UserService(this));
            _sportTypeService = _sportTypeService.InitLazy(new SportTypeService(this));
            _gameRoomService = _gameRoomService.InitLazy(new GameRoomService(this));
            _matchService = _matchService.InitLazy(new MatchService(this));
            _moderationManager = _moderationManager.InitLazy(new ModerationManager(this));
        }

        internal SportsDbContext Context { get; }
        public UserManager<User> UserManager { get; }
        public RoleManager<Role> RoleManager { get; }
        public SignInManager<User> SignInManager { get; }
        public IModerationManager ModerationManager => _moderationManager.Value;
        public IEventService Events => _eventService.Value;
        public IUserService Users => _userService.Value;
        public ISportTypeService SportTypes => _sportTypeService.Value;
        public IGameRoomService GameRooms => _gameRoomService.Value;
        public IMatchService Matches => _matchService.Value;


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
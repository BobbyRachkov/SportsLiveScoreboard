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

        public SportsData(SportsDbContext dbContext, UserManager<User> userManager, RoleManager<Role> roleManager,
            SignInManager<User> signInManager)
        {
            Context = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;

            eventService = eventService.InitLazy(new EventService(this));
        }
        internal SportsDbContext Context { get; }

        public UserManager<User> UserManager => _userManager;
        public RoleManager<Role> RoleManager => _roleManager;
        public SignInManager<User> SignInManager => _signInManager;
        public IEventService Events => eventService.Value;


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
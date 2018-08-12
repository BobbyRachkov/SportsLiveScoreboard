using System;
using Microsoft.AspNetCore.Identity;
using SportsLiveScoreboard.Data;
using SportsLiveScoreboard.Data.Models.Identity;

namespace SportsLiveScoreboard.Services.Data
{
    public class SportsData
    {
        private readonly SportsDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public SportsData(SportsDbContext dbContext,UserManager<User> userManager,RoleManager<Role> roleManager,SignInManager<User> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public UserManager<User> UserManager => _userManager;
        public RoleManager<Role> RoleManager => _roleManager;
        public SignInManager<User> SignInManager => _signInManager;
    }
}

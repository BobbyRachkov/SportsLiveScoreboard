using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportsLiveScoreboard.Data.Models.Identity;

namespace SportsLiveScoreboard.Data
{
    public class SportDbContext : IdentityDbContext<User,Role,string>
    {
        public SportDbContext(DbContextOptions<SportDbContext> options)
            : base(options)
        {
        }
        
    }
}

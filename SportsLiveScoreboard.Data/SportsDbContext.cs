using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportsLiveScoreboard.Data.Models;
using SportsLiveScoreboard.Data.Models.Game.Models;
using SportsLiveScoreboard.Data.Models.Identity;

namespace SportsLiveScoreboard.Data
{
    public class SportsDbContext : IdentityDbContext<User, Role, string>
    {
        public SportsDbContext(DbContextOptions<SportsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Competitor> Competitors { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<GameRoom> GameRooms { get; set; }
        public DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Match>()
                .HasOne(x => x.Winner)
                .WithMany(x => x.Wins)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Match>()
                .HasOne(x => x.Loser)
                .WithMany(x => x.Losses)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Match>()
                .HasOne(x => x.Competitor1)
                .WithMany(x => x.MatchesAsCompetitor1)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Match>()
                .HasOne(x => x.Competitor2)
                .WithMany(x => x.MatchesAsCompetitor2)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Match>()
                .HasOne(x => x.Points);

            builder.Entity<Competitor>()
                .HasOne(x => x.CompetitorFromMatch);

            builder.Entity<UserEvents>()
                .HasKey(x => new {x.UserId, x.EventId});
        }
    }
}
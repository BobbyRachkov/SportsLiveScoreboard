using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportsLiveScoreboard.Data.Models;
using SportsLiveScoreboard.Data.Models.Game;
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
        public DbSet<SportType> SportTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Match>()
                .HasOne(x => x.Competitor1)
                .WithMany(x => x.MatchesAsCompetitor1);
            builder.Entity<Match>()
                .HasOne(x => x.Competitor2)
                .WithMany(x => x.MatchesAsCompetitor2);

            builder.Entity<Competitor>()
                .HasMany(x => x.MatchesAsCompetitor1)
                .WithOne(x => x.Competitor1)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.Entity<Competitor>()
                .HasMany(x => x.MatchesAsCompetitor2)
                .WithOne(x => x.Competitor2)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Competitor>()
                .HasOne(x => x.CompetitorFromMatch);

            builder.Entity<UserEvents>()
                .HasKey(x => new {x.UserId, x.EventId});

            builder.Entity<User>()
                .HasMany(x => x.Events)
                .WithOne(x => x.Owner);
            builder.Entity<UserEvents>()
                .HasOne(x=>x.Event)
                .WithMany(x=>x.Moderators);
            builder.Entity<UserEvents>()
                .HasOne(x => x.User)
                .WithMany(x => x.EventsInModeration);

            builder.Entity<Match>()
                .HasOne(x => x.Room)
                .WithMany(x => x.Matches)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
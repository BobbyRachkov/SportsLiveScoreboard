using System.Collections.Generic;
using System.Linq;
using SportsLiveScoreboard.Data.Models.Game;

namespace SportsLiveScoreboard.Data.SeedingExtensions
{
    public static class SportTypeSeedingExtensions
    {
        public static List<string> sportTypes = new List<string>
        {
            "Table Tennis",
            "Basketball",
            "Volleyball"
        };

        public static SportsDbContext SeedSportTypes(this SportsDbContext context)
        {
            foreach (string sportType in sportTypes)
            {
                if (!context.SportTypes.Any(x => x.Name == sportType))
                {
                    context.SportTypes.Add(new SportType {Name = sportType});
                }
            }

            return context;
        }
    }
}
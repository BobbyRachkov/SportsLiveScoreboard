using System;
using System.Linq;
using SportsLiveScoreboard.Data.Models.Identity;

namespace SportsLiveScoreboard.Data.SeedingExtensions
{
    public static class RoleSeedingExtensions
    {
        public static SportsDbContext SeedRoles(this SportsDbContext context)
        {
            foreach (string name in Enum.GetNames(typeof(RoleType)))
            {
                if (!context.Roles.Any(x=>x.Name==name))
                {
                    context.Roles.Add(new Role {Name = name});
                }
            }

            return context;
        }
    }
}
using System;
using Microsoft.AspNetCore.Identity;

namespace SportsLiveScoreboard.Data.Models.Identity
{
    public class Role : IdentityRole<string>
    {
        public Role()
        {
        }

        public Role(RoleType roleType) : base(roleType.ToString())
        {
            RoleType = roleType;
        }

        public RoleType RoleType { get; }

        public override bool Equals(object obj)
        {
            if (!(obj is Role role))
            {
                return false;
            }
            return RoleType == role.RoleType;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + RoleType.GetHashCode();
        }
    }
}
using System;

namespace SportsLiveScoreboard.Data.Models.Identity
{
    [Flags]
    public enum RoleType
    {
        Administrator,
        User
    }
}
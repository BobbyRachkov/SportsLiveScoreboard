using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Cmp;
using SportsLiveScoreboard.Data.Models;
using SportsLiveScoreboard.Data.Models.Identity;
using SportsLiveScoreboard.Extensions;
using SportsLiveScoreboard.Services.Data;

namespace SportsLiveScoreboard.Web.Architecture
{
    public class SportController : Controller
    {
        private Lazy<User> lazyUser;

        protected readonly ISportsData Data;
        protected User DbUser => lazyUser.Value;


        public SportController(ISportsData data)
        {
            Data = data;
            lazyUser = new Lazy<User>(() => data.UserManager.GetUserAsync(User).Result);
        }

        protected bool IsOwnerOrAdministrator(Event evnt)
        {
            return evnt.OwnerId == DbUser.Id ||
                   Data.UserManager.IsInRoleAsync(DbUser, nameof(RoleType.Administrator)).Result;
        }
        protected bool IsOwnerOrAdministrator(Event evnt, User user)
        {
            return evnt.OwnerId == user.Id ||
                   Data.UserManager.IsInRoleAsync(user, nameof(RoleType.Administrator)).Result;
        }
    }
}
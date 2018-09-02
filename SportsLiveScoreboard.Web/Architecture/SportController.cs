using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Cmp;
using SportsLiveScoreboard.Data.Models;
using SportsLiveScoreboard.Data.Models.Game;
using SportsLiveScoreboard.Data.Models.Identity;
using SportsLiveScoreboard.Extensions;
using SportsLiveScoreboard.Services.Data;

namespace SportsLiveScoreboard.Web.Architecture
{
    public class SportController : Controller
    {
        private readonly Lazy<User> _lazyUser;

        protected readonly ISportsData Data;
        protected User DbUser => _lazyUser.Value;


        public SportController(ISportsData data)
        {
            Data = data;
            _lazyUser = new Lazy<User>(() => data.UserManager.GetUserAsync(User).Result);
        }
    }
}
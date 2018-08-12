using System;
using System.Collections.Generic;
using SportsLiveScoreboard.Data.Models.Game.Models;

namespace SportsLiveScoreboard.Data.Models.Game.Abstractions
{
    public interface IGamePlayable
    {
        List<Score> Games { get; set; }
        int MaxGamesCount { get; set; }
        bool IsGamePlayable { get; set; }
    }
}
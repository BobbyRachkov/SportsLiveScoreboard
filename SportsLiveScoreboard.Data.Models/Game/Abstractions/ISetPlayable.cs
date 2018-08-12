using System.Collections.Generic;
using SportsLiveScoreboard.Data.Models.Game.Models;

namespace SportsLiveScoreboard.Data.Models.Game.Abstractions
{
    public interface ISetPlayable
    {
        List<Score> Sets { get; set; }
        int MaxSetsCount { get; set; }
        bool IsSetPlayable { get; set; }
    }
}
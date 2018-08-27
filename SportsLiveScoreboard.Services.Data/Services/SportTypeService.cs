using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsLiveScoreboard.Data.Models.Game;
using SportsLiveScoreboard.Services.Data.Abstraction;
using SportsLiveScoreboard.Services.Data.Contracts;

namespace SportsLiveScoreboard.Services.Data.Services
{
    public class SportTypeService : DataServiceBase<SportType, int, SportTypeService>, ISportTypeService
    {
        public SportTypeService(SportsData data) : base(data)
        {
        }

        public async Task<SportType> GetByNameAsync(string name)
        {
            return await CurrentDbSet.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsLiveScoreboard.Data;
using SportsLiveScoreboard.Data.Models;
using SportsLiveScoreboard.Services.Data.Abstraction;
using SportsLiveScoreboard.Services.Data.Contracts;

namespace SportsLiveScoreboard.Services.Data.Services
{
    public class EventService : DataServiceBase<Event, string, EventService>, IEventService
    {
        public EventService(SportsData data) : base(data)
        {
        }

        public bool ExistsWithCode(string code)
        {
            code = code.ToLower();
            return Any(x => x.Code == code);
        }

        public Event GetByIdWithIncludedModerators(string id)
        {
            return CurrentDbSet.Include(x => x.Moderators).ThenInclude(x => x.User).FirstOrDefault(x => x.Id == id);
        }

        public override Task<Event> AddAsync(Event entity)
        {
            entity.Code = entity.Code.ToLower();
            return base.AddAsync(entity);
        }

        public async Task<Event> GetByEventCode(string code)
        {
            code = code.ToLower();
            return await GetFirstAsync(x => x.Code == code);
        }

        public async Task<Event> GetByIdWithIncludedRoomsAndMatches(string id) =>
            await CurrentDbSet
                .Include(x => x.Rooms)
                .ThenInclude(x => x.Matches)
                .Include(x=>x.Rooms)
                .ThenInclude(x=>x.SportType)
                .FirstOrDefaultAsync(x => x.Id == id);
    }
}
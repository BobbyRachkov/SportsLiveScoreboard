using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsLiveScoreboard.Data.Models.Identity;
using SportsLiveScoreboard.Services.Data.Contracts;

namespace SportsLiveScoreboard.Services.Data.Services
{
    public class UserService : IUserService
    {
        protected readonly SportsData Data;
        private IQueryable<User> _query;


        public UserService(SportsData data)
        {
            Data = data;
            CurrentDbSet = data.Context.Users;
            ResetQuery();
        }

        private DbSet<User> CurrentDbSet { get; }


        public bool Any(Expression<Func<User, bool>> predicate)
        {
            return CurrentDbSet.Any(predicate);
        }

        public virtual IQueryable<User> All()
        {
            return CurrentDbSet.AsQueryable();
        }


        public virtual async Task<User> GetAsync(string id)
        {
            User result = await _query.FirstOrDefaultAsync(x => x.Id == id);
            ResetQuery();
            return result;
        }

        public virtual async Task<User> GetFirstAsync(Expression<Func<User, bool>> predicate)
        {
            User result = await _query.FirstOrDefaultAsync(predicate);
            ResetQuery();
            return result;
        }

        public virtual IEnumerable<User> GetWhere(Expression<Func<User, bool>> predicate)
        {
            IEnumerable<User> result = _query.Where(predicate).ToList();
            ResetQuery();
            return result;
        }


        public UserService Include<TProp>(Expression<Func<User, TProp>> navigationPropertyPath)
        {
            _query = _query.Include(navigationPropertyPath);
            return this;
        }

        public UserService OrderBy<TProp>(Expression<Func<User, TProp>> property)
        {
            _query = _query.OrderBy(property);
            return this;
        }

        public UserService OrderByDescending<TProp>(Expression<Func<User, TProp>> property)
        {
            _query = _query.OrderByDescending(property);
            return this;
        }

        public void ResetQuery()
        {
            _query = CurrentDbSet.AsQueryable();
        }


        public virtual void Delete(User entity)
        {
            CurrentDbSet.Remove(entity);
        }
    }
}
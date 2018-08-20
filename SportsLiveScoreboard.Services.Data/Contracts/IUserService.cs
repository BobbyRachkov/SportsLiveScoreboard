using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SportsLiveScoreboard.Data.Models.Identity;
using SportsLiveScoreboard.Services.Data.Services;

namespace SportsLiveScoreboard.Services.Data.Contracts
{
    public interface IUserService
    {
        bool Any(Expression<Func<User, bool>> predicate);
        void Delete(User entity);
        Task<User> GetAsync(string id);
        Task<User> GetFirstAsync(Expression<Func<User, bool>> predicate);
        IEnumerable<User> GetWhere(Expression<Func<User, bool>> predicate);
        UserService Include<TProp>(Expression<Func<User, TProp>> navigationPropertyPath);
        UserService OrderBy<TProp>(Expression<Func<User, TProp>> property);
        UserService OrderByDescending<TProp>(Expression<Func<User, TProp>> property);
        void ResetQuery();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SportsLiveScoreboard.Data.Models.Abstraction;

namespace SportsLiveScoreboard.Services.Data.Abstraction
{
    public interface IDataService<T, in TKey, out TService> where T : class, IEntity<TKey>, new()
        where TService : DataServiceBase<T, TKey, TService>
    {
        //IQueryable<T> All();
        Task<T> AddAsync();
        Task<T> AddAsync(T entity);
        bool Any(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(TKey id);
        Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate);
        TService Include<TProp>(Expression<Func<T, TProp>> navigationPropertyPath);
        TService OrderBy<TProp>(Expression<Func<T, TProp>> property);
        TService OrderByDescending<TProp>(Expression<Func<T, TProp>> property);
        void ResetQuery();

        void Delete(T entity);

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
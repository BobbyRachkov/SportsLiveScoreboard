using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SportsLiveScoreboard.Data.Models.Abstraction;

namespace SportsLiveScoreboard.Services.Data.Abstraction
{
    public abstract class DataServiceBase<T, TKey, TService> : IDataService<T, TKey, TService>
        where T : class, IEntity<TKey>, new() where TService : DataServiceBase<T, TKey, TService>
    {
        protected readonly SportsData Data;
        private IQueryable<T> _query;


        protected DataServiceBase(SportsData data)
        {
            Data = data;
            CurrentDbSet = data.Context.Set<T>();
            ResetQuery();
        }

        protected DbSet<T> CurrentDbSet { get; }


        public virtual async Task<T> AddAsync()
        {
            T entity = new T();
            entity = (await CurrentDbSet.AddAsync(entity)).Entity;
            return entity;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            entity = (await CurrentDbSet.AddAsync(entity)).Entity;
            return entity;
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return CurrentDbSet.Any(predicate);
        }

        public virtual IQueryable<T> All()
        {
            return CurrentDbSet.AsQueryable();
        }


        public virtual async Task<T> GetAsync(TKey id)
        {
            T result = await _query.FirstOrDefaultAsync(x => x.Id.Equals(id));
            ResetQuery();
            return result;
        }

        public virtual async Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate)
        {
            T result = await _query.FirstOrDefaultAsync(predicate);
            ResetQuery();
            return result;
        }

        public virtual IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> result = _query.Where(predicate).ToList();
            ResetQuery();
            return result;
        }


        public TService Include<TProp>(Expression<Func<T, TProp>> navigationPropertyPath)
        {
            _query = _query.Include(navigationPropertyPath);
            return (TService)this;
        }

        public TService OrderBy<TProp>(Expression<Func<T, TProp>> property)
        {
            _query = _query.OrderBy(property);
            return (TService) this;
        }

        public TService OrderByDescending<TProp>(Expression<Func<T, TProp>> property)
        {
            _query = _query.OrderByDescending(property);
            return (TService) this;
        }

        public void ResetQuery()
        {
            _query = CurrentDbSet.AsQueryable();
        }


        public virtual void Delete(T entity)
        {
            CurrentDbSet.Remove(entity);
        }


        public void SaveChanges()
        {
            Data.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await Data.SaveChangesAsync();
        }
    }
}
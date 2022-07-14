using Core.Interfaces.Repository;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly SandboxContext _sandboxContext;
        protected readonly DbSet<T> DbSet;

        public Repository(SandboxContext sandboxContext)
        {
            _sandboxContext = sandboxContext;
            DbSet = _sandboxContext.Set<T>();
        }

        public IQueryable<T> GetQuery(
            Expression<Func<T, bool>>? filter,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
            string includeProperties = "")
        {
            IQueryable<T> set = filter == null ? _sandboxContext.Set<T>() :
                 _sandboxContext.Set<T>().Where(filter);

            if (!string.IsNullOrEmpty(includeProperties))
            {
                set = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(set, (current, includeProperty)
                        => current.Include(includeProperty));
            }

            if (orderBy != null)
            {
                set = orderBy(set);
            }

            return set;
        }

        public async Task<IList<T>> GetAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "",
            bool asNoTracking = false)
        {
            var query = GetQuery(filter, orderBy, includeProperties);

            if (asNoTracking)

            {   
                var noTrackingResult = await query.AsNoTracking()
                    .ToListAsync();

                return noTrackingResult;
            }

            var trackingResult = await query.ToListAsync();
            return trackingResult;

        }

        public async Task<IList<T>> QueryAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            int? take = null, int skip = 0,
            bool asNoTracking = false)
        {
            var query = DbSet.AsQueryable().Skip(skip);

            if (asNoTracking)
                query = query.AsNoTracking();

            if (include is not null)
                query = include(query);

            if (filter is not null)
                query = query.Where(filter);

            if (orderBy is not null)
                query = orderBy(query);

            if (take is not null)
                query = query.Take(take.Value);

            return await query.ToListAsync();
        }

        public async Task<T?> GetFirstOrDefaultAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool asNoTracking = false)
        {
            var query = await QueryAsync(
                filter: filter,
                include: include,
                asNoTracking: asNoTracking
            );

            return query.SingleOrDefault();
        }

        public async Task<T?> GetById(int id, string includeProperties = "")
        {
            if (string.IsNullOrEmpty(includeProperties))
            {
                return await _sandboxContext.Set<T>().FindAsync(id);
            }

            var result = await _sandboxContext.Set<T>().FindAsync(id);

            IQueryable<T> set = _sandboxContext.Set<T>();

            set = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(set, (current, includeProperty)
                        => current.Include(includeProperty));

            return await set.FirstOrDefaultAsync(entity => entity == result);
        }

        public void Delete(T entity)
        {
            if (_sandboxContext.Entry(entity).State == EntityState.Detached)
            {
                _sandboxContext.Attach(entity);
            }

            _sandboxContext.Entry(entity).State = EntityState.Deleted;
        }

        public void Update(T entity)
        {
            if (_sandboxContext.Entry(entity).State == EntityState.Detached)
            {
                _sandboxContext.Attach(entity);
            }

            _sandboxContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task InsertAsync(T entity)
        {
            await _sandboxContext.Set<T>().AddAsync(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _sandboxContext.SaveChangesAsync();
        }
    }
}

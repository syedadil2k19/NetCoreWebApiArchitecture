using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Web.API.Application.Interface.Repository;

namespace Web.API.Infrastructure.Repository
{
    /// <inheritdoc/>
    public class EntityFrameworkGenericReadOnlyRepository<TContext> : IGenericReadOnlyRepository where TContext : DbContext
    {
        public EntityFrameworkGenericReadOnlyRepository(TContext mContext)
        {
            context = mContext;
        }

        private readonly TContext context;

        protected TContext Context => context;

        protected virtual IQueryable<TEntity> GetQueryable<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            includeProperties = includeProperties ?? String.Empty;
            foreach (var property in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(property);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if(skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if(take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        public virtual IEnumerable<TEntity> GetAll<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
        {
            return GetQueryable<TEntity>(null, orderBy, includeProperties, skip, take).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
        {
            return await GetQueryable<TEntity>(null, orderBy, includeProperties, skip, take).ToListAsync().ConfigureAwait(false);
        }

        public virtual IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
        {
            return GetQueryable<TEntity>(filter, orderBy, includeProperties, skip, take).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
        {
            return await GetQueryable<TEntity>(filter, orderBy, includeProperties, skip, take).ToListAsync().ConfigureAwait(false);
        }

        public virtual TEntity GetFirst<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) where TEntity : class
        {
            return GetQueryable<TEntity>(filter, orderBy, includeProperties).FirstOrDefault();
        }

        public virtual async Task<TEntity> GetFirstAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) where TEntity : class
        {
            return await GetQueryable<TEntity>(filter, orderBy, includeProperties).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public virtual TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class
        {
            return GetQueryable<TEntity>(filter, null, includeProperties).SingleOrDefault();
        }

        public virtual async Task<TEntity> GetOneAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class
        {
            return await GetQueryable<TEntity>(filter, null, includeProperties).SingleOrDefaultAsync().ConfigureAwait(false);
        }

        public virtual TEntity GetById<TEntity>(object id) where TEntity : class
        {
            return context.Set<TEntity>().Find(id);
        }

        public virtual async Task<TEntity> GetByIdAsync<TEntity>(object id) where TEntity : class
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public virtual int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            return GetQueryable<TEntity>(filter).Count();
        }

        public virtual async Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            return await GetQueryable<TEntity>(filter).CountAsync().ConfigureAwait(false);
        }

        public virtual bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            return GetQueryable<TEntity>(filter).Any();
        }

        public virtual async Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            return await GetQueryable<TEntity>(filter).AnyAsync().ConfigureAwait(false);
        }
    }
}

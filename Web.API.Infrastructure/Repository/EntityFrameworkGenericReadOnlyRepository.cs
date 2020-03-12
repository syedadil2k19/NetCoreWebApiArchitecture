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
            Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public TEntity GetById<TEntity>(object id) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync<TEntity>(object id) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public TEntity GetFirst<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetFirstAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetOneAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class
        {
            throw new NotImplementedException();
        }
    }
}

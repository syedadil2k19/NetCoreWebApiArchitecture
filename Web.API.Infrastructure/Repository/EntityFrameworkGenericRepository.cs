using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Web.API.Application.Interface.Repository;

namespace Web.API.Infrastructure.Repository
{
    public class EntityFrameworkGenericRepository<TContext> : EntityFrameworkGenericReadOnlyRepository<TContext>, IGenericRepository where TContext : DbContext
    {
        public EntityFrameworkGenericRepository(TContext mContext) : base(mContext) { }

        public void Create<TEntity>(TEntity entity) where TEntity : class
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void Delete<TEntity>(object id) where TEntity : class
        {
            var entityToRemove = Context.Set<TEntity>().Find(id);
            Delete(entityToRemove);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void SaveAsync()
        {
            Context.SaveChangesAsync();
        }
    }
}

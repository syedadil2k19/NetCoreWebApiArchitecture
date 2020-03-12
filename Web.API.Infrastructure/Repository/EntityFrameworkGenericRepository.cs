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
            throw new NotImplementedException();
        }

        public void Delete<TEntity>(object id) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}

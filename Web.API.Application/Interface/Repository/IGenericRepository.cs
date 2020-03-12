using System;
using System.Collections.Generic;
using System.Text;

namespace Web.API.Application.Interface.Repository
{
    public interface IGenericRepository : IGenericReadOnlyRepository
    {
        /// <summary>
        /// Adds an entity of arbitrary type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="entity">An entity of type <typeparamref name="TEntity"/>.</param>
        /// <typeparam name="TEntity">Type of entity to be added.</typeparam>
        void Create<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Deletes the entity of arbitrary type <typeparamref name="TEntity"/> that is identified by <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the entity to be deleted.</param>
        /// <typeparam name="TEntity">Type of entity to be deleted.</typeparam>
        void Delete<TEntity>(object id) where TEntity : class;

        /// <summary>
        /// Deletes the given <paramref name="entity"/> of arbitrary type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="id">An entity of type <typeparamref name="TEntity"/>.</param>
        /// <typeparam name="TEntity">Type of entity to be deleted.</typeparam>
        void Delete<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Saves the changes performed on entities in the current scope.
        /// </summary>
        void Save();

        /// <summary>
        /// Saves the changes performed on entities in the current scope, asynchronously.
        /// </summary>
        void SaveAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Application.Interface.Repository
{
    public interface IGenericReadOnlyRepository
    {
        /// <summary>
        /// <para>Gets a list of all entities of type <typeparamref name="TEntity"/>.</para>
        /// Use the parameters to modify the list as required.
        /// </summary>
        /// <param name="orderBy">
        /// <para><c>Optional</c> - Delegate that accepts a list of <typeparamref name="TEntity"/> and returns the list ordered by the given expression.</para>
        /// Expects a lambda expression as argument.
        /// </param>
        /// <param name="includeProperties">
        /// <c>Optional</c> - A string containing comma seperated values of property names of <typeparamref name="TEntity"/> to load eagerly.
        /// </param>
        /// <param name="skip">
        /// <c>Optional</c> - An integer denoting the number of entries to exclude. Counted from start.
        /// </param>
        /// <param name="take">
        /// <c>Optional</c> - An integer denoting the number of entries to include. Counted from start of the current list entries.
        /// </param>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <returns>A list of <typeparamref name="TEntity"/>.</returns>
        IEnumerable<TEntity> GetAll<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity: class;

        /// <summary>
        /// <para>Gets a list of all entities of type <typeparamref name="TEntity"/> asynchronously.</para>
        /// Use the parameters to modify the list as required.
        /// </summary>
        /// <param name="orderBy">
        /// <para><c>Optional</c> - Delegate that accepts a list of <typeparamref name="TEntity"/> and returns the list ordered by the given expression.</para>
        /// Expects a lambda expression as argument.
        /// </param>
        /// <param name="includeProperties">
        /// <c>Optional</c> - A string containing comma seperated values of property names of <typeparamref name="TEntity"/> to load eagerly.
        /// </param>
        /// <param name="skip">
        /// <c>Optional</c> - An integer denoting the number of entries to exclude. Counted from start.
        /// </param>
        /// <param name="take">
        /// <c>Optional</c> - An integer denoting the number of entries to include. Counted from start of the current list entries.
        /// </param>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <returns>A list of <typeparamref name="TEntity"/>.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class;

        /// <summary>
        /// <para>Gets a list of entities of type <typeparamref name="TEntity"/> that satisfy the condition contained in <paramref name="filter"/>.</para>
        /// Use the other parameters to modify the list as required.
        /// </summary>
        /// <param name="filter">
        /// <para>Expression that specifies the condition using which the list of <typeparamref name="TEntity"/> must be retrieved.</para>
        /// Expects a lambda expression as arugument.
        /// </param>
        /// <param name="orderBy">
        /// <para><c>Optional</c> - Delegate that accepts a list of <typeparamref name="TEntity"/> and returns the list ordered by the given expression.</para>
        /// Expects a lambda expression as argument.
        /// </param>
        /// <param name="includeProperties">
        /// <c>Optional</c> - A string containing comma seperated values of property names of <typeparamref name="TEntity"/> to load eagerly.
        /// </param>
        /// <param name="skip">
        /// <c>Optional</c> - An integer denoting the number of entries to exclude. Counted from start.
        /// </param>
        /// <param name="take">
        /// <c>Optional</c> - An integer denoting the number of entries to include. Counted from start of the current list entries.
        /// </param>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <returns>A list of <typeparamref name="TEntity"/>.</returns>
        IEnumerable<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class;

        /// <summary>
        /// <para>Gets a list of entities of type <typeparamref name="TEntity"/>, that satisfy the condition contained in <paramref name="filter"/>, asynchronously.</para>
        /// Use the other parameters to modify the list as required.
        /// </summary>
        /// <param name="filter">
        /// <para>Expression that specifies the condition using which the list of <typeparamref name="TEntity"/> must be retrieved.</para>
        /// Expects a lambda expression as arugument.
        /// </param>
        /// <param name="orderBy">
        /// <para><c>Optional</c> - Delegate that accepts a list of <typeparamref name="TEntity"/> and returns the list ordered by the given expression.</para>
        /// Expects a lambda expression as argument.
        /// </param>
        /// <param name="includeProperties">
        /// <c>Optional</c> - A string containing comma seperated values of property names of <typeparamref name="TEntity"/> to load eagerly.
        /// </param>
        /// <param name="skip">
        /// <c>Optional</c> - An integer denoting the number of entries to exclude. Counted from start.
        /// </param>
        /// <param name="take">
        /// <c>Optional</c> - An integer denoting the number of entries to include. Counted from start of the current list entries.
        /// </param>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <returns>A list of <typeparamref name="TEntity"/>.</returns>
        Task<IEnumerable<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class;

        /// <summary>
        /// Gets the first entry in a list entities of type <typeparamref name="TEntity"/> that satisfy the condition contained in <paramref name="filter"/>.
        /// </summary>
        /// <param name="filter">
        /// <para>
        /// <c>Optional</c> - Expression that specifies the condition using which the list of <typeparamref name="TEntity"/> must be retrieved.
        /// </para>
        /// Expects a lambda expression as argument.
        /// </param>
        /// <param name="includeProperties">
        /// <c>Optional</c> - A string containing comma seperated values of property names of <typeparamref name="TEntity"/> to load eagerly.
        /// </param>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <returns>An object of type <typeparamref name="TEntity"/>.</returns>
        TEntity GetOne<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null)
            where TEntity : class;

        /// <summary>
        /// Gets the first entry in a list entities of type <typeparamref name="TEntity"/>, that satisfy the condition contained in <paramref name="filter"/>,
        /// asynchronously.
        /// </summary>
        /// <param name="filter">
        /// <para>
        /// <c>Optional</c> - Expression that specifies the condition using which the list of <typeparamref name="TEntity"/> must be retrieved.
        /// </para>
        /// Expects a lambda expression as argument.
        /// </param>
        /// <param name="includeProperties">
        /// <c>Optional</c> - A string containing comma seperated values of property names of <typeparamref name="TEntity"/> to load eagerly.
        /// </param>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <returns>An object of type <typeparamref name="TEntity"/>.</returns>
        Task<TEntity> GetOneAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null)
            where TEntity : class;

        /// <summary>
        /// Gets the first entry in a list entities of type <typeparamref name="TEntity"/>, that satisfy the condition contained in <paramref name="filter"/>.
        /// </summary>
        /// <param name="filter">
        /// <para>
        /// <c>Optional</c> - Expression that specifies the condition using which the list of <typeparamref name="TEntity"/> must be retrieved.
        /// </para>
        /// Expects a lambda expression as argument.
        /// </param>
        /// <param name="orderBy">
        /// <para><c>Optional</c> - Delegate that accepts a list of <typeparamref name="TEntity"/> and returns the list ordered by the given expression.</para>
        /// Expects a lambda expression as argument.
        /// </param>
        /// <param name="includeProperties">
        /// <c>Optional</c> - A string containing comma seperated values of property names of <typeparamref name="TEntity"/> to load eagerly.
        /// </param>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <returns>An object of <typeparamref name="TEntity"/>.</returns>
        TEntity GetFirst<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null)
            where TEntity : class;

        /// <summary>
        /// Gets the first entry in a list entities of type <typeparamref name="TEntity"/>, that satisfy the condition contained in <paramref name="filter"/>, asynchronously.
        /// </summary>
        /// <param name="filter">
        /// <para>
        /// <c>Optional</c> - Expression that specifies the condition using which the list of <typeparamref name="TEntity"/> must be retrieved.
        /// </para>
        /// Expects a lambda expression as argument.
        /// </param>
        /// <param name="orderBy">
        /// <para><c>Optional</c> - Delegate that accepts a list of <typeparamref name="TEntity"/> and returns the list ordered by the given expression.</para>
        /// Expects a lambda expression as argument.
        /// </param>
        /// <param name="includeProperties">
        /// <c>Optional</c> - A string containing comma seperated values of property names of <typeparamref name="TEntity"/> to load eagerly.
        /// </param>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <returns>An object of <typeparamref name="TEntity"/>.</returns>
        Task<TEntity> GetFirstAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null)
            where TEntity : class;

        /// <summary>
        /// Gets an entity of type <typeparamref name="TEntity"/> using its <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of entity to get.</param>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <returns>An object of <typeparamref name="TEntity"/>.</returns>
        TEntity GetById<TEntity>(object id)
            where TEntity : class;

        /// <summary>
        /// Gets an entity of type <typeparamref name="TEntity"/> using its <paramref name="id"/> asynchronously.
        /// </summary>
        /// <param name="id">The id of entity to get.</param>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <returns>An object of <typeparamref name="TEntity"/>.</returns>
        Task<TEntity> GetByIdAsync<TEntity>(object id)
            where TEntity : class;

        /// <summary>
        /// Gets the count of entities that satisfy the condition contained in <paramref name="filter"/>.
        /// </summary>
        /// <param name="filter">
        /// <para>
        /// <c>Optional</c> - Expression that specifies the condition using which the list of entities must be retrieved.
        /// </para>
        /// Expects a lambda expression as argument.
        /// </param>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <returns>Number of entities that remain after <paramref name="filter"/>.</returns>
        int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class;

        /// <summary>
        /// Gets the count of entities that satisfy the condition contained in <paramref name="filter"/> asynchronously.
        /// </summary>
        /// <param name="filter">
        /// <para>
        /// <c>Optional</c> - Expression that specifies the condition using which the list of entities must be retrieved.
        /// </para>
        /// Expects a lambda expression as argument.
        /// </param>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <returns>Number of entities that remain after <paramref name="filter"/>.</returns>
        Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class;

        /// <summary>
        /// Checks if any entity matches the condition contained in <paramref name="filter"/>.
        /// </summary>
        /// <param name="filter">
        /// <para>
        /// <c>Optional</c> - Expression that specifies the condition using which the list of entities must be retrieved.
        /// </para>
        /// Expects a lambda expression as argument.
        /// </param>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <returns>true or false</returns>
        bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter)
            where TEntity : class;

        /// <summary>
        /// Checks, asynchronously, if any entity matches the condition contained in <paramref name="filter"/>.
        /// </summary>
        /// <param name="filter">
        /// <para>
        /// <c>Optional</c> - Expression that specifies the condition using which the list of entities must be retrieved.
        /// </para>
        /// Expects a lambda expression as argument.
        /// </param>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <returns>true or false</returns>
        Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter)
            where TEntity : class;

    }
}

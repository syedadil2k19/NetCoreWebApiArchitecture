using Microsoft.EntityFrameworkCore;
using System;
using Web.API.Domain.Entity.User;

namespace Web.API.Infrastructure
{
    /// <summary>Serves as the database context class for this API.</summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class ApiContext : DbContext
    {
        /// <summary>
        /// <para>
        /// A public constructor for this database context class that accepts <see cref="DbContextOptions"/>
        /// and simply passes it to its base class constructor.
        /// </para>
        /// NOTE: Required when the database context is set using <see cref="Microsoft.Extensions.DependencyInjection.EntityFrameworkServiceCollectionExtensions.AddDbContext"/> on IServiceCollection
        /// </summary>
        /// <param name="options">A <see cref="DbContextOptions"/> object</param>
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        /// <summary>
        /// <para>Represents entities modelled after <see cref="User"/> data model</para>
        /// By convention, this creates a database table named "Users"
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}

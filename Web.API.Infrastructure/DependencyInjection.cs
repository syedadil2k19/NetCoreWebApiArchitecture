using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using Web.API.Application.Interface.Repository;
using Web.API.Infrastructure.Repository;

namespace Web.API.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddDbContext<ApiContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly("Web.API")));

            services.TryAdd(ServiceDescriptor.Scoped(typeof(IGenericReadOnlyRepository), typeof(EntityFrameworkGenericReadOnlyRepository<ApiContext>)));
            services.TryAdd(ServiceDescriptor.Scoped(typeof(IGenericRepository), typeof(EntityFrameworkGenericRepository<ApiContext>)));

            return services;
        }
    }
}

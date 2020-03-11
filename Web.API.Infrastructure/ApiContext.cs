using Microsoft.EntityFrameworkCore;
using System;
using Web.API.Domain.Entity.User;

namespace Web.API.Infrastructure
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}

using System;
using Microsoft.EntityFrameworkCore;

namespace eWAN.Infrastructure.Database
{
    using Entities;

    public class EwanContext : DbContext
    {
        public EwanContext(DbContextOptions options) : base(options) {}

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if(builder is null)
            {
                throw new ArgumentNullException(nameof(builder)); 
            }

            builder.ApplyConfigurationsFromAssembly(typeof(EwanContext).Assembly);
        }
    }
}

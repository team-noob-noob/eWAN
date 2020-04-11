using Microsoft.EntityFrameworkCore;
using eWAN.Core.Domains.Security;
using eWAN.Core.Infrastructure.Database.Config;

namespace eWAN.Core.Infrastructure.Database
{
    public sealed class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions options)
            : base(options) {}

        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchoolContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=school.db");
    }
}

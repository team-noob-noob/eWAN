using Microsoft.EntityFrameworkCore;
using eWAN.Core.Domains.Entities.Identity;
using eWAN.Core.Infrastructure.Database.Config;

namespace eWAN.Core.Infrastructure.Database
{
    public class SchoolContext : DbContext
    {
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=school.db");
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using eWAN.Infrastructure.Database.Entities;
namespace eWAN.Infrastructure.Database
{
    public class EwanIdentityDbContext : IdentityDbContext<Identity>
    {
        public EwanIdentityDbContext(DbContextOptions options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost;Database=ewan_identity;Uid=root;Pwd=root;";
            optionsBuilder.UseMySql(
                connectionString,
                options => {
                    options.ServerVersion(new Version(5, 7, 32), Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql);
                    options.MaxBatchSize(1);
                }
            );
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
        }

    }
}

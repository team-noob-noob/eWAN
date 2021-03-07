using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Sinuka.Core.Infrastructure.Database
{
    public class SinukaDbContextFactory : IDesignTimeDbContextFactory<SinukaDbContext>
    {
        public SinukaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SinukaDbContext>();
            optionsBuilder.UseMySql(
                Sinuka.Core.Infrastructure.Configs.DbConfig.DbConnectionString,
                options => {
                    options.ServerVersion(Sinuka.Core.Infrastructure.Configs.DbConfig.MySqlVersion, Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql);
                    options.MaxBatchSize(1);
                }
            );
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
            return new SinukaDbContext(optionsBuilder.Options);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace eWAN.Core.Infrastructure.Database
{
    public class EwanDbContextFactory : IDesignTimeDbContextFactory<EwanDbContext>
    {
        public EwanDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EwanDbContext>();
            optionsBuilder.UseMySql(
                eWAN.Core.Infrastructure.Configuration.DbConfig.DbConnectionString,
                options => {
                    options.ServerVersion(eWAN.Core.Infrastructure.Configuration.DbConfig.MySqlVersion, Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql);
                    options.MaxBatchSize(1);
                }
            );
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
            return new EwanDbContext(optionsBuilder.Options);
        }
    }
}

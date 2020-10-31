using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace eWAN.Infrastructure.Database
{
    public class ContextFactory : IDesignTimeDbContextFactory<EwanContext>
    {
        public EwanContext CreateDbContext(string[] args)
        {
            string connectionString = "Server=localhost;Database=ewan;Uid=root;Pwd=root;";
            var builder = new DbContextOptionsBuilder<EwanContext>();
            builder.UseMySql(
                connectionString,
                options => {
                    options.ServerVersion(new Version(8, 0, 20), Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql);
                }
            );
            return new EwanContext(builder.Options);
        }
    }
}

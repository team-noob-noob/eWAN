using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace eWAN.Infrastructure.Database
{
    public class EwanIdentityDbContextFactory : IDesignTimeDbContextFactory<EwanIdentityDbContext>
    {
        public EwanIdentityDbContext CreateDbContext(string[] args)
        {
            string connectionString = "Server=localhost;Database=ewan_identity;Uid=root;Pwd=root;";
            var builder = new DbContextOptionsBuilder<EwanIdentityDbContext>();
            builder.UseMySql(
                connectionString,
                options => {
                    options.ServerVersion(new Version(8, 0, 20), Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql);
                }
            );
            return new EwanIdentityDbContext(builder.Options);
        }
    }
}

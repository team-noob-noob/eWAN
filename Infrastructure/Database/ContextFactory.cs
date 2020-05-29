using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace eWAN.Infrastructure.Database
{
    public class ContextFactory : IDesignTimeDbContextFactory<EwanContext>
    {
        public EwanContext CreateDbContext(string[] args)
        {
            string connectionString = "";
            var builder = new DbContextOptionsBuilder<EwanContext>();
            builder.UseMySQL(connectionString);
            return new EwanContext(builder.Options);
        }
    }
}

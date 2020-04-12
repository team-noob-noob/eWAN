using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace eWAN.Core.Infrastructure.Database
{
    public sealed class ContextFactory : IDesignTimeDbContextFactory<SchoolContext>
    {
        public SchoolContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SchoolContext>();
            builder.UseSqlite("testing");
            return new SchoolContext(builder.Options);
        }
    }
}

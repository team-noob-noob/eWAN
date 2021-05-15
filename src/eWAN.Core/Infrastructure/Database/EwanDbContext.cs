using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace eWAN.Core.Infrastructure.Database
{
    public class EwanDbContext : DbContext
    {
       public EwanDbContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(EwanDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                eWAN.Core.Infrastructure.Configuration.DbConfig.DbConnectionString,
                options => {
                    options.ServerVersion(eWAN.Core.Infrastructure.Configuration.DbConfig.MySqlVersion, Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql);
                    options.MaxBatchSize(1);
                }
            );
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
        }

        private void UpdateEntities()
        {
            var newEntitites = this.ChangeTracker.Entries()
            .Where(
                x =>
                    x.State == EntityState.Added && 
                    !(x.Entity is null) && 
                    !(x.Entity as eWAN.Core.Domains.Entities.Base.IEntity is null)
            )
            .Select(x => x.Entity as eWAN.Core.Domains.Entities.Base.IEntity);

            var modifiedEntities = this.ChangeTracker.Entries()
            .Where(
                x =>
                    x.State == EntityState.Modified && 
                    !(x.Entity is null) && 
                    !(x.Entity as eWAN.Core.Domains.Entities.Base.IEntity is null)
            )
            .Select(x => x.Entity as eWAN.Core.Domains.Entities.Base.IEntity);

            var currentTime = DateTime.UtcNow;

            foreach(var newEntity in newEntitites)
            {
                newEntity.CreatedAt = currentTime;
                newEntity.UpdatedAt = currentTime;
            }

            foreach(var modifiedEntity in modifiedEntities)
                modifiedEntity.UpdatedAt = currentTime;
        }

        public override int SaveChanges()
        {
            this.UpdateEntities();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            this.UpdateEntities();
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

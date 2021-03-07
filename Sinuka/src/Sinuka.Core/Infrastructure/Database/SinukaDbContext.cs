using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Sinuka.Core.Domains.Entities;

namespace Sinuka.Core.Infrastructure.Database
{
    public class SinukaDbContext : IdentityDbContext<User, Role, string, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public SinukaDbContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(SinukaDbContext).Assembly);
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                Sinuka.Core.Infrastructure.Configs.DbConfig.DbConnectionString,
                options => {
                    options.ServerVersion(Sinuka.Core.Infrastructure.Configs.DbConfig.MySqlVersion, Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql);
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
                    !(x.Entity as Sinuka.Core.Domains.Entities.Base.IEntity is null)
            )
            .Select(x => x.Entity as Sinuka.Core.Domains.Entities.Base.IEntity);

            var modifiedEntities = this.ChangeTracker.Entries()
            .Where(
                x =>
                    x.State == EntityState.Modified && 
                    !(x.Entity is null) && 
                    !(x.Entity as Sinuka.Core.Domains.Entities.Base.IEntity is null)
            )
            .Select(x => x.Entity as Sinuka.Core.Domains.Entities.Base.IEntity);

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

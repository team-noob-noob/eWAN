using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eWAN.Infrastructure.Database
{
    using Entities;
    using Domains;
    using Microsoft.Extensions.Logging;

    public class EwanContext : DbContext
    {
        public EwanContext(DbContextOptions options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Role> UserRoles { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<EnrolledSubject> EnrolledSubjects { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<EnrolledProgram> EnrolledPrograms { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if(builder is null)
            {
                throw new ArgumentNullException(nameof(builder)); 
            }
            builder.ApplyConfigurationsFromAssembly(typeof(EwanContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost;Database=ewan;Uid=root;Pwd=root;";
            optionsBuilder.UseMySql(
                connectionString,
                options => {
                    options.ServerVersion(new Version(8, 0, 20), Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql);
                    options.MaxBatchSize(1);
                }
            );
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
        }

        private void UpdateEntities()
        {
            var newEntities = this.ChangeTracker.Entries()
                .Where(
                    x => x.State == EntityState.Added &&
                    x.Entity != null &&
                    x.Entity as IBaseEntity != null
                    )
                .Select(x => x.Entity as IBaseEntity);

            var modifiedEntities = this.ChangeTracker.Entries() 
                .Where(
                    x => x.State == EntityState.Modified &&
                    x.Entity != null &&
                    x.Entity as IBaseEntity != null
                    )
                .Select(x => x.Entity as IBaseEntity);

            var currentTime = DateTime.Now;

            foreach (var newEntity in newEntities)
            {
                newEntity.UpdatedAt = currentTime;
            }

            foreach (var modifiedEntity in modifiedEntities)
            {
                modifiedEntity.UpdatedAt = currentTime;
            }
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

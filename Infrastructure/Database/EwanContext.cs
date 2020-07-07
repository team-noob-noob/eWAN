using System;
using Microsoft.EntityFrameworkCore;


namespace eWAN.Infrastructure.Database
{
    using Entities;
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
            if(!optionsBuilder.IsConfigured)
            {
                string connectionString = "Server=localhost;Database=ewan;Uid=root;Pwd=root;";
                optionsBuilder.UseMySQL(connectionString);
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using eWAN.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eWAN.Infrastructure.Database.Configuration
{

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .HasOne<User>(x => (User) x.User)
                .WithOne(x => (Student) x.StudentProfile)
                .HasForeignKey<Student>(x => x.UserId)
                .IsRequired(false);
        }
    }
}

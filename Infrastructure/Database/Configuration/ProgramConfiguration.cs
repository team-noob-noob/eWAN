using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eWAN.Infrastructure.Database.Configuration
{
    using Domains.Program;
    using Program = Entities.Program;
    using Course = Entities.Course;
    using System.Linq;

    public class ProgramConfiguration : IEntityTypeConfiguration<Program>
    {
        public void Configure(EntityTypeBuilder<Program> builder)
        {
            builder
                .HasMany<Course>(x => x.Courses.Cast<Course>())
                .WithOne()
                .HasForeignKey("CourseId");
            builder.ToTable("Programs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}

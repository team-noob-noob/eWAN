using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace eWAN.Infrastructure.Database.Configuration
{
    using Domains.Course;
    using Course = Entities.Course;
    using Entities;

    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                .HasMany(course => (IEnumerable<Course>) course.Prerequisites)
                .WithOne()
                .HasForeignKey("ParentId")
                .IsRequired(false);
            
            builder.HasMany<Subject>();

            builder.ToTable("Courses");
        }
    }
}
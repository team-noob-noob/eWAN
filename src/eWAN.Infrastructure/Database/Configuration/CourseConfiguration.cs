using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace eWAN.Infrastructure.Database.Configuration
{
    using Domains.Course;
    using Course = Entities.Course;
    using Entities;
    using System.Linq;

    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                .HasMany<Course>(course => (IEnumerable<Course>) course.Prerequisites)
                .WithOne(course => (Course) course.Prerequesite)
                .HasForeignKey(course => course.ParentCourse_Id)
                .IsRequired(false);
            
            builder
                .HasMany<Subject>(x => (IEnumerable<Subject>) x.OpenedSubjects)
                .WithOne(y => (Course) y.Course)
                .IsRequired(false);

            builder.HasKey(x => x.Id);

            builder.ToTable("Courses");
        }
    }
}

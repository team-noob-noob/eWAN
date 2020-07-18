using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace eWAN.Infrastructure.Database.Configuration
{
    using System.Linq;
    using Entities;
    using Semester = Entities.Semester;

    public sealed class SemesterConfiguration : IEntityTypeConfiguration<Semester>
    {
        public void Configure(EntityTypeBuilder<Semester> builder)
        {
            builder
                .HasMany<Subject>(x => x.OpenCourses.Cast<Subject>())
                .WithOne()
                .HasForeignKey("SemesterId");

            builder.ToTable("Semesters");
        }
    }
}

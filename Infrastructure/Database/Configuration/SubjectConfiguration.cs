using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace eWAN.Infrastructure.Database.Configuration
{
    using System.Linq;
    using Entities;
    using Subject = Entities.Subject;

    public sealed class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder
                .HasOne(x => (Course) x.Course)
                .WithMany()
                .HasForeignKey("CourseId");
            
            builder
                .HasMany<Session>(x => x.Sessions.Cast<Session>())
                .WithOne()
                .HasForeignKey("SubjectId");
            
            builder
                .HasMany<EnrolledSubject>(x => x.Students.Cast<EnrolledSubject>())
                .WithOne();

            builder.ToTable("Subjects");
        }
    }
}

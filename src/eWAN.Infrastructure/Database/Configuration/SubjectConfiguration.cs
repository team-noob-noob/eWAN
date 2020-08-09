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
                .WithMany(y => (IEnumerable<Subject>) y.OpenedSubjects)
                .HasForeignKey("CourseId");
            
            builder
                .HasMany<Session>(x => (IEnumerable<Session>) x.Sessions)
                .WithOne(y => (Subject) y.Subject)
                .HasForeignKey("SubjectId");

            builder.HasKey(x => x.Id);

            builder.ToTable("Subjects");
        }
    }
}

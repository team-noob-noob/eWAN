using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace eWAN.Infrastructure.Database.Configuration
{
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
                .HasMany<Session>(x => (IEnumerable<Session>) x.Sessions)
                .WithOne()
                .HasForeignKey("SubjectId");
            
            builder
                .HasMany<User>(x => (IEnumerable<User>) x.Students)
                .WithOne()
                .HasForeignKey("SubjectId");

            builder.ToTable("Subjects");
        }
    }
}

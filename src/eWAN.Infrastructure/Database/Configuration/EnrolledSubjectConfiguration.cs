using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace eWAN.Infrastructure.Database.Configuration
{
    using Entities;
    using EnrolledSubject = Entities.EnrolledSubject;

    public sealed class EnrolledSubjectConfiguration : IEntityTypeConfiguration<EnrolledSubject>
    {
        public void Configure(EntityTypeBuilder<EnrolledSubject> builder)
        {
            builder
                .HasOne<Student>(x => (Student) x.EnrolledStudent)
                .WithMany(y => (IEnumerable<EnrolledSubject>) y.EnrolledSubjects)
                .HasForeignKey(x => x.User_Id);

            builder
                .HasOne<Subject>(x => (Subject) x.Subject)
                .WithMany(y => (IEnumerable<EnrolledSubject>) y.StudentsEnrolled)
                .HasForeignKey(x => x.Subject_Id);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.ToTable("EnrolledSubjects");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eWAN.Infrastructure.Database.Configuration
{
    using Entities;
    using EnrolledSubject = Entities.EnrolledSubject;

    public sealed class EnrolledSubjectConfiguration : IEntityTypeConfiguration<EnrolledSubject>
    {
        public void Configure(EntityTypeBuilder<EnrolledSubject> builder)
        {
            builder.HasOne<User>(x => (User) x.enrolledStudent);

            builder.HasOne<Subject>(x => (Subject) x.subject);

            builder.ToTable("EnrolledSubjects");
        }
    }
}

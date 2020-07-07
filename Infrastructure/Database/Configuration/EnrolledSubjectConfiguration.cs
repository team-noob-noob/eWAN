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
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne<User>(x => (User) x.enrolledStudent);

            builder.HasOne<Subject>(x => (Subject) x.subject);

            builder.ToTable("EnrolledSubjects");
        }
    }
}

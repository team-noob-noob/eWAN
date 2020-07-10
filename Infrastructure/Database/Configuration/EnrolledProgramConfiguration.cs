using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eWAN.Infrastructure.Database.Configuration
{
    using Entities;
    using EnrolledProgram = Entities.EnrolledProgram;

    public sealed class EnrolledProgramConfiguration : IEntityTypeConfiguration<EnrolledProgram>
    {
        public void Configure(EntityTypeBuilder<EnrolledProgram> builder)
        {
            builder.HasOne<User>(x => (User) x.Student);

            builder.HasOne<Program>(x => (Program) x.Program);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.ToTable("EnrolledProgram");
        }
    }
}

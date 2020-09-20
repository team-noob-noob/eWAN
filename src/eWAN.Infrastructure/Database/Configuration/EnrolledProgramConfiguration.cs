using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace eWAN.Infrastructure.Database.Configuration
{
    using Entities;
    using EnrolledProgram = Entities.EnrolledProgram;
    using Program = Entities.Program;

    public sealed class EnrolledProgramConfiguration : IEntityTypeConfiguration<EnrolledProgram>
    {
        public void Configure(EntityTypeBuilder<EnrolledProgram> builder)
        {
            builder
                .HasOne<Student>(x => (Student) x.Student)
                .WithMany(y => (IEnumerable<EnrolledProgram>) y.EnrolledPrograms)
                .HasForeignKey(x => x.Student_Id);

            builder
                .HasOne<Program>(x => (Program) x.Program)
                .WithMany(y => (IEnumerable<EnrolledProgram>) y.EnrolledStudentsInProgram)
                .HasForeignKey(x => x.Program_Id);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.ToTable("EnrolledProgram");
        }
    }
}

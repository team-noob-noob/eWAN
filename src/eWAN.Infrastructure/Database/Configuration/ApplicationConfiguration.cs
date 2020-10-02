using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eWAN.Infrastructure.Database.Configuration
{
    using Domains.Application;
    using User = Entities.User;
    using Application = Entities.Application;

    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder
                .HasOne<User>(x => (User) x.applicant)
                .WithMany()
                .HasForeignKey(x => x.Applicant_Id)
                .IsRequired(false);
            
            builder
                .HasOne<User>(x => (User) x.staff)
                .WithOne()
                .HasForeignKey<Application>(x => x.Staff_Id)
                .IsRequired(false);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.ToTable("Applications");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eWAN.Infrastructure.Database.Configuration
{
    using Domains.Application;
    using User = Entities.User;

    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasOne<User>(x => (User) x.applicant);
            builder.HasOne<User>(x => (User) x.staff);

            builder.ToTable("Applications");
        }
    }
}

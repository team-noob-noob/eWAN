using eWAN.Core.Domains.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eWAN.Core.Infrastructure.Database.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.OwnsOne(u => u.details);
            builder.OwnsOne(u => u.contacts, cb => cb.OwnsOne(c => c.homeAddress));
            builder.OwnsOne(u => u.guardian);
        }
    }
}

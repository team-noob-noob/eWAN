using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinuka.Core.Domains.Entities;

namespace Sinuka.Core.Infrastructure.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Sinuka.Core.Domains.Entities.User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinuka.Core.Domains.Entities;

namespace Sinuka.Core.Infrastructure.Database.Configurations
{
    public class UserLoginConfiguration : IEntityTypeConfiguration<Sinuka.Core.Domains.Entities.UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.ToTable("UserLogins");
        }
    }
}

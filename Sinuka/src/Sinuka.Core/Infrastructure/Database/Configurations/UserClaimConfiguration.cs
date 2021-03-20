using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinuka.Core.Domains.Entities;

namespace Sinuka.Core.Infrastructure.Database.Configurations
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<Sinuka.Core.Domains.Entities.UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.ToTable("UserClaims");
        }
    }
}

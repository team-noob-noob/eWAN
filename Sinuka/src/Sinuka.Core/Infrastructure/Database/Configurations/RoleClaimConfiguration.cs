using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinuka.Core.Domains.Entities;

namespace Sinuka.Core.Infrastructure.Database.Configurations
{
    public class RoleClaimConfiguration : IEntityTypeConfiguration<Sinuka.Core.Domains.Entities.RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.ToTable("RoleClaims");
        }
    }
}

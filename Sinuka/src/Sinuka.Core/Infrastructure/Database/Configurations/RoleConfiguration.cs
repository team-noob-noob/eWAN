using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinuka.Core.Domains.Entities;

namespace Sinuka.Core.Infrastructure.Database.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Sinuka.Core.Domains.Entities.Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
        }
    }
}

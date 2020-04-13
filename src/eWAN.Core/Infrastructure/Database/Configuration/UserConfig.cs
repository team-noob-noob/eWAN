using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using eWAN.Core.Infrastructure.Database.Entities;
using ExternalUserId = eWAN.Core.Domains.Security.ExternalUserId;
using AccountId = eWAN.Core.Domains.Account.AccountId;

namespace eWAN.Core.Infrastructure.Database.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(b => b.externalUserId);

            builder.Property(b => b.externalUserId)
                .HasConversion(
                    v => v.ToGuid(),
                    v => new ExternalUserId(v)
                )
                .IsRequired();
            
            builder.Property(b => b.accountId)
                .HasConversion(
                    v => v.ToString(),
                    v => new AccountId(v)
                )
                .IsRequired();
            
            builder.HasKey(
                c => new {c.externalUserId, c.accountId}
            );
        }
    }
}

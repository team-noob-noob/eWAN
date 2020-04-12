using eWAN.Core.Domains.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eWAN.Core.Infrastructure.Database.Config
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasIndex(b => b.accountId);

            builder.Property(b => b.accountId)
                .HasConversion(
                    v => v.ToString(),
                    v => new AccountId(v)
                )
                .IsRequired();

            builder.OwnsOne(a => a.name);
            builder.OwnsOne(a => a.guardian, a => {
                a.OwnsOne(b => b.mobileNumber);
            });
            builder.OwnsOne(a => a.contacts, a => {
                a.OwnsOne(b => b.homeAddress);
                a.OwnsOne(b => b.mobileNumber);
            });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;

namespace eWAN.Infrastructure.Database.Configuration
{
    using Domains.User;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            if(builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("User");

            builder.HasKey(x => x.Id);
        }
    }
}

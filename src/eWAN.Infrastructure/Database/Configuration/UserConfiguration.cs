using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
    
namespace eWAN.Infrastructure.Database.Configuration
{
    using Domains.User;
    using User = Entities.User;
    using Role = Entities.Role;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            if(builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder
                .HasMany<Role>(x => (IEnumerable<Role>) x.AssignedRoles)
                .WithOne(y => (User) y.User)
                .HasForeignKey(x => x.User_Id);

            builder.ToTable("User");

            builder.HasKey(x => x.Id);
        }
    }
}

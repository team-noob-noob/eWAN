using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace eWAN.Infrastructure.Database.Configuration
{
    using Entities;
    using Session = Entities.Session;

    public sealed class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasOne<Room>(x => (Room) x.Room);

            builder.HasOne<User>(x => (User) x.Instructor);

            builder.ToTable("Sessions");
        }
    }
}

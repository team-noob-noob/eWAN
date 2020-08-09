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
            builder.HasOne<Room>(x => (Room) x.Room).WithMany(y => (IEnumerable<Session>) y.Schedule);

            builder.HasOne<User>(x => (User) x.Instructor);

            builder.HasKey(x => x.Id);

            builder.ToTable("Sessions");
        }
    }
}

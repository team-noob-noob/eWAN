using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eWAN.Infrastructure.Database.Configuration
{
    using Room = Entities.Room;

    public sealed class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Rooms");
        }
    }
}

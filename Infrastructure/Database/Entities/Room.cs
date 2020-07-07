namespace eWAN.Infrastructure.Database.Entities
{
    using Domains.Room;

    public sealed class Room : Domains.Room.Room, IRoom
    {
        public override string Id { get; set; }
        public override string Name { get; set; }
        public override string Address { get; set; }
    }
}

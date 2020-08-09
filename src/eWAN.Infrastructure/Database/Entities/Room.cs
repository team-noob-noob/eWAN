namespace eWAN.Infrastructure.Database.Entities
{
    using System.Collections.Generic;
    using Domains.Room;
    using Domains.Session;

    public sealed class Room : Domains.Room.Room, IRoom
    {
        public Room() {}
        public Room(string Id, string Name, string Address = null)
        {
            this.Id = Id;
            this.Name = Name;
            this.Address = Address;
        }

        public override string Id { get; set; }
        public override string Name { get; set; }
        public override string Address { get; set; }
        public override List<ISession> Schedule { get; set; }
    }
}

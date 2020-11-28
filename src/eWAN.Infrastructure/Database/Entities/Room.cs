namespace eWAN.Infrastructure.Database.Entities
{
    using System.Collections.Generic;
    using Domains.Room;
    using Domains.Session;

    public class Room : Domains.Room.Room, IRoom
    {
        public Room() {}
        public Room(string Code, string Name, string Address = null)
        {
            this.Code = Code;
            this.Name = Name;
            this.Address = Address;
        }

        public override string Code { get; set; }
        public override string Name { get; set; }
        public override string Address { get; set; }
    }
}

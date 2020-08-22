using System.Collections.Generic;

namespace eWAN.Domains.Room
{
    using Session;

    public abstract class Room : BaseEntity, IRoom
    {
        public abstract string Id { get; set; }
        public abstract string Name { get; set; }
        public abstract string Address { get; set; }
        public virtual List<ISession> Schedule { get; set; } = new List<ISession>();
    }
}
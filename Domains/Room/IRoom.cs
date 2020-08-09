using System.Collections.Generic;

namespace eWAN.Domains.Room
{
    using Session;

    public interface IRoom : IBaseEntity
    {
        string Id { get; }
        string Name { get; set; }
        string Address { get; set; }

        // Inverse Property
        List<ISession> Schedule { get; set; }
    }
}

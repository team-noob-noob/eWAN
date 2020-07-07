using System.Collections.Generic;

namespace eWAN.Domains.Section
{
    using User;

    public interface ISection
    {
        int Id { get; set; }
        string Name { get; set; }
        IEnumerable<IUser> Students { get; set; }
    }
}

using System.Collections.Generic;

namespace eWAN.Domains.Section
{
    using User;

    public interface ISection
    {
        int Id { get; set; }
        string Name { get; set; }
        List<IUser> Students { get; set; }
    }
}

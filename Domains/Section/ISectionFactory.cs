using System.Collections.Generic;

namespace eWAN.Domains.Section
{
    using User;

    public interface ISectionFactory
    {
        ISection NewSection(
            string Name,
            List<IUser> Students
        );
    }
}

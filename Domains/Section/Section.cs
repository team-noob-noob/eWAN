using System.Collections.Generic;
using eWAN.Domains.User;

namespace eWAN.Domains.Section
{
    public abstract class Section : BaseEntity, ISection
    {
        public abstract int Id { get; set; }

        public abstract string Name { get; set; }
        public abstract List<IUser> Students { get; set; }
    }
}

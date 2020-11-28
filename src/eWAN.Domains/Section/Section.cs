using System.Collections.Generic;
using eWAN.Domains.Student;

namespace eWAN.Domains.Section
{
    public abstract class Section : BaseEntity, ISection
    {
        public abstract string Name { get; set; }
        public virtual List<IStudent> Students { get; set; } = new List<IStudent>();
    }
}

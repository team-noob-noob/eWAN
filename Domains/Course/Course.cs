using System.Collections.Generic;

namespace eWAN.Domains.Course
{
    public abstract class Course : BaseEntity, ICourse
    {
        public abstract string Id { get; set; }
        public abstract string Title { get; set; }
        public abstract string Description { get; set; }
        public abstract IEnumerable<ICourse> Prerequisites { get; set; }
    }
}

using System.Collections.Generic;
using eWAN.Domains.Course;

namespace eWAN.Domains.Program
{
    public abstract class Program : BaseEntity, IProgram
    {
        public abstract int Id { get; set; }
        public abstract string Title { get; set; }
        public abstract string Description { get; set; }
        public abstract IEnumerable<ICourse> Courses { get; set; }
    }
}

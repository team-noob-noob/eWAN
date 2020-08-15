using System.Collections.Generic;
using eWAN.Domains.Course;
using eWAN.Domains.EnrolledProgram;

namespace eWAN.Domains.Program
{
    public abstract class Program : BaseEntity, IProgram
    {
        public abstract int Id { get; set; }
        public abstract string Code { get; set; }
        public abstract string Title { get; set; }
        public abstract string Description { get; set; }
        public virtual List<ICourse> Courses { get; set; }
        public virtual List<IEnrolledProgram> EnrolledStudentsInProgram { get; set; }
    }
}

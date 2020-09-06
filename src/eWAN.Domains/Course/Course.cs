using System.Collections.Generic;
using eWAN.Domains.Program;
using eWAN.Domains.Subject;

namespace eWAN.Domains.Course
{
    public abstract class Course : BaseEntity, ICourse
    {
        public abstract string Id { get; set; }
        public abstract string Title { get; set; }
        public abstract string Description { get; set; }
        public virtual List<ICourse> Prerequisites { get; set; } = new List<ICourse>();
        public virtual IProgram AssignedProgram { get; set; }
        public virtual List<ISubject> OpenedSubjects { get; set; } = new List<ISubject>();
        public virtual ICourse? Prerequesite { get; set; }
    }
}

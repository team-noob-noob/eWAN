using System.Collections.Generic;

namespace eWAN.Domains.Subject
{
    using Course;
    using Session;
    using EnrolledSubject;
    using Semester;

    public abstract class Subject : BaseEntity, ISubject 
    {
        public abstract string Code { get; set; }
        public virtual ICourse Course { get; set; }
        public virtual List<ISession> Sessions { get; set; } = new List<ISession>();
        public virtual ISemester Semester { get; set; }
        public virtual List<IEnrolledSubject> StudentsEnrolled { get; set; } = new List<IEnrolledSubject>();
    }
}

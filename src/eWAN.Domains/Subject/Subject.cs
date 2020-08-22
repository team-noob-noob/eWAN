using System.Collections.Generic;

namespace eWAN.Domains.Subject
{
    using Domains.Course;
    using Domains.Session;
    using Domains.EnrolledSubject;
    using eWAN.Domains.Semester;

    public abstract class Subject : BaseEntity, ISubject 
    {
        public abstract string Id { get; set; }
        public virtual ICourse Course { get; set; }
        public virtual List<ISession> Sessions { get; set; } = new List<ISession>();
        public virtual ISemester Semester { get; set; }
        public virtual List<IEnrolledSubject> StudentsEnrolled { get; set; } = new List<IEnrolledSubject>();
    }
}

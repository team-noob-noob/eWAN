namespace eWAN.Infrastructure.Database.Entities
{
    using System.Collections.Generic;
    using Domains.Subject;
    using Domains.Course;
    using Domains.Session;
    using Domains.EnrolledSubject;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using eWAN.Domains.Semester;

    public sealed class Subject : Domains.Subject.Subject, ISubject
    {
        public Subject() {}
        public Subject(ICourse course, List<ISession> sessions)
        {
            this.Course = course;
            this.Sessions = sessions;
            this.Id = "SUBJ-" + DateTime.Now.Year + new Random().NewString(10, "0123456789");
        }

        public override string Id { get; set; }
        public override ICourse Course { get; set; }
        public override List<ISession> Sessions { get; set; }
        public override ISemester Semester { get; set; }
        public override List<IEnrolledSubject> StudentsEnrolled { get; set; }
    }
}

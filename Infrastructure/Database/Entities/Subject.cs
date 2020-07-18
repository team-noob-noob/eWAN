namespace eWAN.Infrastructure.Database.Entities
{
    using System.Collections.Generic;
    using Domains.Subject;
    using Domains.Course;
    using Domains.Session;
    using Domains.EnrolledSubject;
    using System;

    public sealed class Subject : Domains.Subject.Subject, ISubject
    {
        public Subject() {}
        public Subject(ICourse course, IEnumerable<ISession> sessions, IEnumerable<IEnrolledSubject> Students)
        {
            this.Course = course;
            this.Sessions = sessions;
            this.Students = Students;
            this.Id = "SUBJ-" + DateTime.Now.Year + new Random().NewString(10, "0123456789");
        }

        public override string Id { get; set; }
        public override ICourse Course { get; set; }
        public override IEnumerable<ISession> Sessions { get; set; }
        public override IEnumerable<IEnrolledSubject> Students { get; set; }
    }
}

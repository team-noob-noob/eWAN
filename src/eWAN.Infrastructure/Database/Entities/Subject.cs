using System.Collections.Generic;
using eWAN.Domains.Subject;
using eWAN.Domains.Course;
using eWAN.Domains.Session;
using System;

namespace eWAN.Infrastructure.Database.Entities
{
    public class Subject : Domains.Subject.Subject, ISubject
    {
        public Subject() {}
        public Subject(ICourse course, List<ISession> sessions)
        {
            this.Course = course;
            this.Sessions = sessions;
            this.Code = "SUBJ-" + DateTime.Now.Year + new Random().NewString(10, "0123456789");
        }

        public override string Code { get; set; }
    }
}

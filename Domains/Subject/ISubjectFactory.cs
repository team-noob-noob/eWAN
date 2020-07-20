using System.Collections.Generic;

namespace eWAN.Domains.Subject
{
    using Course;
    using Session;
    using EnrolledSubject;

    public interface ISubjectFactory
    {
        ISubject NewSubject(
            ICourse course,
            List<ISession> sessions
        );
    }
}

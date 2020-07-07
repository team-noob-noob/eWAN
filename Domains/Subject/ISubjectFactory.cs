using System.Collections.Generic;

namespace eWAN.Domains.Subject
{
    using Course;
    using Session;
    using User;

    public interface ISubjectFactory
    {
        ISubject NewSubject(
            string id,
            ICourse course,
            List<ISession> sessions,
            List<IUser> students
        );
    }
}

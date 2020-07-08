using System.Collections.Generic;

namespace eWAN.Domains.Subject
{
    using Session;
    using EnrolledSubject;
    using Course;

    public interface ISubject : IBaseEntity
    {
        string Id { get; set; }
        ICourse Course { get; set; }
        IEnumerable<ISession> Sessions { get; set; }
        IEnumerable<IEnrolledSubject> Students { get; set; }
    }
}

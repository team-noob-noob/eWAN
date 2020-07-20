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
        List<ISession> Sessions { get; set; }
    }
}

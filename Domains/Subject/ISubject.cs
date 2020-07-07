using System.Collections.Generic;

namespace eWAN.Domains.Subject
{
    using Session;
    using User;
    using Course;

    public interface ISubject : IBaseEntity
    {
        string Id { get; set; }
        ICourse Course { get; set; }
        IEnumerable<ISession> Sessions { get; set; }
        IEnumerable<IUser> Students { get; set; }
    }
}

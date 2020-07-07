using System.Collections.Generic;
using eWAN.Domains.Course;
using eWAN.Domains.Session;
using eWAN.Domains.User;

namespace eWAN.Domains.Subject
{
    public abstract class Subject : BaseEntity, ISubject 
    {
        public abstract string Id { get; set; }
        public abstract ICourse Course { get; set; }
        public abstract IEnumerable<ISession> Sessions { get; set; }
        public abstract IEnumerable<IUser> Students { get; set; }
    }
}

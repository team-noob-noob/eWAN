using System.Collections.Generic;

namespace eWAN.Domains.Subject
{
    using Domains.Course;
    using Domains.Session;
    using Domains.EnrolledSubject;


    public abstract class Subject : BaseEntity, ISubject 
    {
        public abstract string Id { get; set; }
        public abstract ICourse Course { get; set; }
        public abstract List<ISession> Sessions { get; set; }
    }
}

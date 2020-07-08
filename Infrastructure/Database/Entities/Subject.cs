namespace eWAN.Infrastructure.Database.Entities
{
    using System.Collections.Generic;
    using Domains.Subject;
    using Domains.Course;
    using Domains.Session;
    using Domains.EnrolledSubject;

    public sealed class Subject : Domains.Subject.Subject, ISubject
    {
        public override string Id { get; set; }
        public override ICourse Course { get; set; }
        public override IEnumerable<ISession> Sessions { get; set; }
        public override IEnumerable<IEnrolledSubject> Students { get; set; }
    }
}

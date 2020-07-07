namespace eWAN.Infrastructure.Database.Entities
{
    using System.Collections.Generic;
    using Domains.Subject;
    using eWAN.Domains.Course;
    using eWAN.Domains.Session;
    using eWAN.Domains.User;

    public sealed class Subject : Domains.Subject.Subject, ISubject
    {
        public override string Id { get; set; }
        public override ICourse Course { get; set; }
        public override IEnumerable<ISession> Sessions { get; set; }
        public override IEnumerable<IUser> Students { get; set; }
    }
}

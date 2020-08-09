using System.Collections.Generic;

namespace eWAN.Domains.Subject
{
    using Session;
    using EnrolledSubject;
    using Course;
    using Semester;

    public interface ISubject : IBaseEntity
    {
        string Id { get; set; }
        ICourse Course { get; set; }
        List<ISession> Sessions { get; set; }

        // Inverse Property
        ISemester Semester { get; set; }
        List<IEnrolledSubject> StudentsEnrolled { get; set; }
    }
}

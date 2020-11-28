using System.Collections.Generic;

namespace eWAN.Domains.Subject
{
    using Session;
    using EnrolledSubject;
    using Course;
    using Semester;

    /// <summary>
    /// Represents a timed Course, broken up into Sessions
    /// </summary>
    public interface ISubject : IBaseEntity
    {
        string Code { get; set; }
        ICourse Course { get; set; }
        List<ISession> Sessions { get; set; }

        // Inverse Property
        ISemester Semester { get; set; }
        List<IEnrolledSubject> StudentsEnrolled { get; set; }
    }
}

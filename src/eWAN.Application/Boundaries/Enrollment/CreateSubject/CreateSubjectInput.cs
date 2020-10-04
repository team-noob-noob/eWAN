using System.Collections.Generic;

namespace eWAN.Application.Boundaries.CreateSubject
{
    using Domains.Course;
    using Domains.Session;
    using Domains.Semester;
    using Domains.User;

    public class CreateSubjectInput
    {
        public ICourse Course { get; set; }
        public List<ISession> Sessions { get; set; }
        public ISemester Semester { get; set; }
        public IUser Instructor { get; set; }
    }
}

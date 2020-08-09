using System;
using System.Collections.Generic;

namespace eWAN.Domains.Semester
{
    using Subject;

    public interface ISemesterFactory
    {
        ISemester AddSemester(
            string Id,
            DateTime Start,
            DateTime End,
            bool IsOpenForEnrollment,
            List<ISubject> OpenCourses
        );
    }
}

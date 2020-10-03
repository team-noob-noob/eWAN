using System;
using System.Collections.Generic;

namespace eWAN.Domains.Semester
{
    using Subject;

    public interface ISemesterFactory
    {
        ISemester AddSemester(
            string id,
            DateTime start,
            DateTime end,
            bool isOpenForEnrollment,
            List<ISubject> openCourses
        );
    }
}

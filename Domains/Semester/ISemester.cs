using System;
using System.Collections.Generic;

namespace eWAN.Domains.Semester
{
    using Subject;

    public interface ISemester
    {
        string Id { get; set; }
        DateTime Start { get; set; }
        DateTime End { get; set; }
        bool IsOpenForEnrollment { get; set; }
        List<ISubject> OpenCourses { get; set; }
    }
}

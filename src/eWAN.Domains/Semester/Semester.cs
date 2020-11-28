using System;
using System.Collections.Generic;
using eWAN.Domains.Subject;

namespace eWAN.Domains.Semester
{
    public abstract class Semester : BaseEntity, ISemester
    {
        public abstract string Code { get; set; }
        public abstract DateTime Start { get; set; }
        public abstract DateTime End { get; set; }
        public abstract bool IsOpenForEnrollment { get; set; }
        public virtual List<ISubject> OpenCourses { get; set; } = new List<ISubject>();
    }
}

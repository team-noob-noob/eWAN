namespace eWAN.Infrastructure.Database.Entities
{
    using System;
    using System.Collections.Generic;
    using Domains.Semester;
    using eWAN.Domains.Subject;

    public sealed class Semester : Domains.Semester.Semester, ISemester
    {
        public override string Id { get; set; }
        public override DateTime Start { get; set; }
        public override DateTime End { get; set; }
        public override bool IsOpenForEnrollment { get; set; }
        public override IEnumerable<ISubject> OpenCourses { get; set; }
    }
}

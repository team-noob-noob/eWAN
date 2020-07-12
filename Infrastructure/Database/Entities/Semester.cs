namespace eWAN.Infrastructure.Database.Entities
{
    using System;
    using System.Collections.Generic;
    using Domains.Semester;
    using eWAN.Domains.Subject;

    public sealed class Semester : Domains.Semester.Semester, ISemester
    {
        public Semester() {}
        public Semester(string Id, DateTime start, DateTime End, IEnumerable<ISubject> courses = null, bool IsOpenForEnrollment = true)
        {
            this.Id = Id;
            this.Start = Start;
            this.End = End;
            this.OpenCourses = courses;
            this.IsOpenForEnrollment = IsOpenForEnrollment;
        }

        public override string Id { get; set; }
        public override DateTime Start { get; set; }
        public override DateTime End { get; set; }
        public override bool IsOpenForEnrollment { get; set; }
        public override IEnumerable<ISubject> OpenCourses { get; set; }
    }
}
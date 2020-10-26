using System;
using System.Collections.Generic;
using eWAN.Domains.Semester;
using eWAN.Domains.Subject;

namespace eWAN.Infrastructure.Database.Entities
{
    public class Semester : Domains.Semester.Semester, ISemester
    {
        public Semester() {}
        public Semester(string Id, DateTime start, DateTime End, List<ISubject> courses = null, bool IsOpenForEnrollment = true)
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
    }
}

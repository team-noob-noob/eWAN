using System.Collections.Generic;

namespace eWAN.Infrastructure.Database.Entities
{
    using Domains.Course;
    using eWAN.Domains.Program;
    using eWAN.Domains.Subject;

    public sealed class Course : Domains.Course.Course, ICourse
    {
        public Course() {}
        public Course(string Id, string Title, string Description, List<ICourse> Prerequisites)
        {
            this.Id = Id;
            this.Title = Title;
            this.Description = Description;
            this.Prerequisites = Prerequisites ?? new List<ICourse>();
        }

        public override string Id { get; set; }
        public override string Title { get; set; }
        public override string Description { get; set; }
        public string ParentCourse_Id { get; set; }
        public int Program_Id { get; set; }
    }
}

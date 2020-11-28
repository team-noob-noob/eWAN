using System.Collections.Generic;
using eWAN.Domains.Program;
using eWAN.Domains.Course;

namespace eWAN.Infrastructure.Database.Entities
{
    public class Course : Domains.Course.Course, ICourse
    {
        public Course() {}
        public Course(string Id, string Title, string Description, List<ICourse> Prerequisites, IProgram program)
        {
            this.Code = Id;
            this.Title = Title;
            this.Description = Description;
            this.Prerequisites = Prerequisites ?? new List<ICourse>();
            this.AssignedProgram = program;
        }

        public override string Title { get; set; }
        public override string Description { get; set; }
        public int? ParentCourse_Id { get; set; }
        public int? Program_Id { get; set; }
        public override string Code { get; set; }
    }
}

using System.Collections.Generic;

namespace eWAN.Infrastructure.Database.Entities
{
    using Domains.Program;
    using eWAN.Domains.Course;
    using eWAN.Domains.EnrolledProgram;

    public class Program : Domains.Program.Program, IProgram
    {
        protected Program() {}
        public Program(string Title, string Code, string Description, List<ICourse> courses)
        {
            this.Title = Title;
            this.Code = Code;
            this.Description = Description;
            this.Courses = courses ?? new List<ICourse>();
        }

        public override int Id { get; set; }
        public override string Code { get; set; }
        public override string Title { get; set; }
        public override string Description { get; set; }
    }
}

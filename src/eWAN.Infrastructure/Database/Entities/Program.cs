using System.Collections.Generic;
using eWAN.Domains.Course;
using eWAN.Domains.EnrolledProgram;
using eWAN.Domains.Program;


namespace eWAN.Infrastructure.Database.Entities
{
        

    public class Program : Domains.Program.Program, IProgram
    {
        public Program() {}
        public Program(string Title, string Code, string Description, List<ICourse> courses)
        {
            this.Title = Title;
            this.Code = Code;
            this.Description = Description;
            this.Courses = courses ?? new List<ICourse>();
        }

        public override string Code { get; set; }
        public override string Title { get; set; }
        public override string Description { get; set; }
    }
}

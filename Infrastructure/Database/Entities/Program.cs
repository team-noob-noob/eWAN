using System.Collections.Generic;

namespace eWAN.Infrastructure.Database.Entities
{
    using Domains.Program;
    using eWAN.Domains.Course;

    public sealed class Program : Domains.Program.Program, IProgram
    {
        public Program() {}
        public Program(string Title, string Description, List<ICourse> courses)
        {
            this.Title = Title;
            this.Description = Description;
            this.Courses = courses ?? new List<ICourse>();
        }

        public override int Id { get; set; }
        public override string Title { get; set; }
        public override string Description { get; set; }
        public override List<ICourse> Courses { get; set; }
    }
}

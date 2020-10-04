namespace eWAN.Application.Boundaries.CreateCourse
{
    using System.Collections.Generic;
    using Domains.Course;
    using Domains.Program;

    public class CreateCourseInput
    {
        public CreateCourseInput(
            string id, 
            string title, 
            string description, 
            List<ICourse> prerequisites,
            IProgram program    
        )
        {
            Id = id;
            Title = title;
            Description = description;
            Prerequisites = prerequisites;
            Program = program;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ICourse> Prerequisites { get; set; }
        public IProgram Program { get; set; }
    }
}

namespace eWAN.Application.Boundaries.CreateCourse
{
    using System.Collections.Generic;
    using Domains.Course;
    using eWAN.Domains.Program;

    public class CreateCourseInput
    {
        public CreateCourseInput(
            string Id, 
            string Title, 
            string Description, 
            List<ICourse> Prerequisites,
            IProgram program    
        )
        {
            this.Id = Id;
            this.Title = Title;
            this.Description = Description;
            this.Prerequisites = Prerequisites;
            this.Program = program;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ICourse> Prerequisites { get; set; }
        public IProgram Program { get; set; }
    }
}

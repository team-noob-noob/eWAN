using System.Collections.Generic;

namespace eWAN.WebApi.UseCases.CreateCourse
{
    public class CreateCourseRequest
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> CourseIds { get; set; }
        public string ProgramId { get; set; }
    }
}

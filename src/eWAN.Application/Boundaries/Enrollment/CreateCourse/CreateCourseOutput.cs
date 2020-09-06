namespace eWAN.Application.Boundaries.CreateCourse
{
    using Domains.Course;

    public class CreateCourseOutput
    {
        public CreateCourseOutput(ICourse course)
        {
            this.Course = course;
        }

        public ICourse Course { get; set; }
    }
}

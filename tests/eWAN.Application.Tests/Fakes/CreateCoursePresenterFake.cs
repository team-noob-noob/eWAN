using eWAN.Application.Boundaries.CreateCourse;

namespace eWAN.Tests.Fakes
{
    public sealed class CreateCoursePresenterFake : ICreateCourseOutputPort
    {
        public CreateCourseOutput StandardOutput;
        public string ErrorOutput;

        public void Standard(CreateCourseOutput output) => this.StandardOutput = output;

        public void WriteError(string message) => this.ErrorOutput = message;
    }
}

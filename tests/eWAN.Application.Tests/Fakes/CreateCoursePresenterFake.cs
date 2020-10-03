using eWAN.Application.Boundaries.CreateCourse;

namespace eWAN.Tests.Fakes
{
    public sealed class CreateCoursePresenterFake : ICreateCourseOutputPort
    {
        public CreateCourseOutput StandardOutput;
        public string ErrorOutput;

        public void Standard(CreateCourseOutput output) => StandardOutput = output;

        public void WriteError(string message) => ErrorOutput = message;
    }
}

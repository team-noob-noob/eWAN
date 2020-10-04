namespace eWAN.Tests.Fakes
{
    using Application.Boundaries.StudentApplication;

    public class StudentApplicationPresenterFake : IStudentApplicationOutputPort
    {
        public StudentApplicationOutput StandardOutput { get; set; }
        public string ErrorOutput { get; set; }

        public void Standard(StudentApplicationOutput output) => StandardOutput = output;

        public void WriteError(string message) => ErrorOutput = message;
    }
}

using eWAN.Application.Boundaries.CreateProgram;

namespace eWAN.Tests.Fakes
{
    public sealed class CreateProgramPresenterFake : ICreateProgramOutputPort
    {
        public CreateProgramOutput StandardOutput;
        public string ErrorOutput;

        public void Standard(CreateProgramOutput output) => StandardOutput = output;

        public void WriteError(string message) => ErrorOutput = message;
    }
}

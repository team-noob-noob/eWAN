using eWAN.Application.Boundaries.CreateProgram;

namespace eWAN.Tests.Fakes
{
    public sealed class CreateProgramPresenterFake : ICreateProgramOutputPort
    {
        public CreateProgramOutput StandardOutput;
        public string ErrorOutput;

        public void Standard(CreateProgramOutput output) => this.StandardOutput = output;

        public void WriteError(string message) => this.ErrorOutput = message;
    }
}

namespace eWAN.Application.Boundaries.CreateProgram
{
    using Domains.Program;

    public class CreateProgramOutput
    {
        public CreateProgramOutput(IProgram program)
        {
            this.Program = program;
        }

        public IProgram Program { get; set; }
    }
}

namespace eWAN.WebApi.UseCases.CreateProgram
{
    public class CreateProgramResponse
    {
        public CreateProgramResponse(string programId)
        {
            ProgramId = programId;
        }

        public string ProgramId { get; set; }
    }
}

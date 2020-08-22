namespace eWAN.WebApi.UseCases.CreateProgram
{
    public class CreateProgramResponse
    {
        public CreateProgramResponse(string ProgramId)
        {
            this.ProgramId = ProgramId;
        }

        public string ProgramId { get; set; }
    }
}

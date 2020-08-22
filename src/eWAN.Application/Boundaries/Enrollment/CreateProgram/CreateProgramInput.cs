namespace eWAN.Application.Boundaries.CreateProgram
{
    public class CreateProgramInput
    {
        public CreateProgramInput(string Title, string Code, string Description)
        {
            this.Title = Title;
            this.Code = Code;
            this.Description = Description;
        }

        public string Title { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}

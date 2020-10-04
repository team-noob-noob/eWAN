namespace eWAN.Application.Boundaries.CreateProgram
{
    public class CreateProgramInput
    {
        public CreateProgramInput(string title, string code, string description)
        {
            Title = title;
            Code = code;
            Description = description;
        }

        public string Title { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}

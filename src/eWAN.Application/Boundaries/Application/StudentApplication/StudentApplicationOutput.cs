namespace eWAN.Application.Boundaries.StudentApplication
{
    public class StudentApplicationOutput
    {
        public StudentApplicationOutput(string id)
        {
            ConfirmationId = id;
        }

        public string ConfirmationId { get; }
    }
}

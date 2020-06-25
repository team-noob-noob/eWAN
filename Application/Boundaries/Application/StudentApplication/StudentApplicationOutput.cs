namespace eWAN.Application.Boundaries.StudentApplication
{
    public class StudentApplicationOutput
    {
        public StudentApplicationOutput(string id)
        {
            this.ConfirmationId = id;
        }

        public string ConfirmationId { get; }
    }
}

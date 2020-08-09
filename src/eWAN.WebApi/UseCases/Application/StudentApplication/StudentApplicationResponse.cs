namespace eWAN.WebApi.UseCases.StudentApplication
{
    public class StudentApplicationResponse
    {
        public StudentApplicationResponse(string ApplicationId)
        {
            this.ApplicationId = ApplicationId;
        }

        public string ApplicationId { get; set; }
    }
}

namespace eWAN.WebApi.UseCases.StudentApplication
{
    public class StudentApplicationResponse
    {
        public StudentApplicationResponse(string applicationId)
        {
            ApplicationId = applicationId;
        }

        public string ApplicationId { get; set; }
    }
}

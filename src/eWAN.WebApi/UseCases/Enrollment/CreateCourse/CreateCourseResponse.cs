namespace eWAN.WebApi.UseCases.CreateCourse
{
    public class CreateCourseResponse
    {
        public CreateCourseResponse(string newCourseId)
        {
            NewCourseId = newCourseId;
        }

        public string NewCourseId { get; set; }
    }
}

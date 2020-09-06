namespace eWAN.WebApi.UseCases.CreateCourse
{
    public class CreateCourseResponse
    {
        public CreateCourseResponse(string NewCourseId)
        {
            this.NewCourseId = NewCourseId;
        }

        public string NewCourseId { get; set; }
    }
}

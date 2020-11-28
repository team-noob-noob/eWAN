using eWAN.Application.Boundaries.CreateCourse;
using Microsoft.AspNetCore.Mvc;

namespace eWAN.WebApi.UseCases.CreateCourse
{
    public class CreateCoursePresenter : ICreateCourseOutputPort
    {
        public IActionResult ViewModel = new NoContentResult();

        public void Standard(CreateCourseOutput output) 
            => ViewModel = new CreatedResult("Course", new CreateCourseResponse(output.Course.Code));

        public void WriteError(string message) => ViewModel = new UnprocessableEntityObjectResult(new {message});
    }
}

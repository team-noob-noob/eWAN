using eWAN.Application.Boundaries.CreateCourse;
using Microsoft.AspNetCore.Mvc;

namespace eWAN.WebApi.UseCases.CreateCourse
{
    public class CreateCoursePresenter : ICreateCourseOutputPort
    {
        public IActionResult ViewModel = new NoContentResult();

        public void Standard(CreateCourseOutput output) 
            => this.ViewModel = new CreatedResult("Course", new CreateCourseResponse(output.Course.Id));

        public void WriteError(string message) => this.ViewModel = new UnprocessableEntityObjectResult(new {message});
    }
}

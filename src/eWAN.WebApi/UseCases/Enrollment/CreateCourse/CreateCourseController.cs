using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using eWAN.Application.UseCases;
using eWAN.Application.Boundaries.CreateCourse;
using eWAN.Domains.Course;
using System.Collections.Generic;
using eWAN.Domains.Program;

namespace eWAN.WebApi.UseCases.CreateCourse
{
    [Authorize]
    [Route("/api/[controller]/[action]")]
    public class CourseController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CreateCourse(
            [FromForm] CreateCourseRequest request,
            [FromServices] CreateCoursePresenter presenter,
            [FromServices] ICreateCourseUseCase useCase,
            [FromServices] ICourseRepository courseRepository,
            [FromServices] IProgramRepository programRepository
        )
        {
            var prerequisites = new List<ICourse>();
            if(request.CourseIds != null)
            {
                foreach(var courseId in request.CourseIds)
                {
                    var course = courseRepository.GetCourseById(courseId);
                    if(course != null)
                    {
                        prerequisites.Add((ICourse) course);
                    }
                }
            }

            var program = await programRepository.GetProgramByCode(request.ProgramId);

            var input = new CreateCourseInput(
                request.Id,
                request.Title,
                request.Description,
                prerequisites,
                program
            );

            await useCase.Handle(input);

            return presenter.ViewModel;
        }
    }
}

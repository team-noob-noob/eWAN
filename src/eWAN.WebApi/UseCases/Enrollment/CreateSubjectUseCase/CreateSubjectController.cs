using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace eWAN.WebApi.UseCases.CreateSubject
{
    using Application.Boundaries.CreateSubject;
    using Domains.Room;
    using Domains.Course;
    using Domains.Semester;
    using Domains.User;

    [Authorize]
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class SubjectController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CreateSubject(
            [FromServices] CreateSubjectPresenter presenter,
            [FromServices] ICreateSubjectUseCase useCase,
            [FromServices] ICourseRepository courseRepository,
            [FromServices] ISemesterRepository semesterRepository,
            [FromServices] IUserRepository userRepository,
            [FromForm] [Required] CreateSubjectRequest request
        )
        {
            var input = new CreateSubjectInput()
            {
                Course = await courseRepository.GetCourseById(request.CourseId),
                Sessions = request.Sessions,
                Semester = await semesterRepository.GetSemesterById(request.SemesterCode),
                Instructor = await userRepository.GetById(request.InstructorId)
            };
            await useCase.Handle(input);
            return presenter.ViewModel;
        }
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace eWAN.WebApi.UseCases.StudentApplication
{
    using Application.Boundaries.StudentApplication;
    using Domains.User;

    [Authorize]
    [Route("/api/[controller]")]
    [ApiController]
    public sealed class StudentApplicationController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PassStudentApplication(
            [FromServices] IStudentApplicationUseCase useCase,
            [FromServices] StudentApplicationPresenter presenter,
            [FromServices] IUserRepository userRepository
        )
        {
            var applicant = await userRepository.GetByUsername(this.HttpContext.User.Identity.Name);
            var input = new StudentApplicationInput(applicant);
            await useCase.Handle(input);
            return presenter.ViewModel;
        }
    }
}

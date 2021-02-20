using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace eWAN.WebApi.UseCases.StudentApplication
{
    using Modules;
    using Application.Boundaries.StudentApplication;
    using Domains.User;
    using Microsoft.AspNetCore.Http;

    [Authorize]
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public sealed class ApplicationController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PassStudentApplication(
            [FromServices] IStudentApplicationUseCase useCase,
            [FromServices] StudentApplicationPresenter presenter,
            [FromServices] IUserRepository userRepository
        )
        {
            var applicant = await userRepository.GetById(HttpContext.User.GetUserId());
            var input = new StudentApplicationInput(applicant);
            await useCase.Handle(input);
            return presenter.ViewModel;
        }
    }
}

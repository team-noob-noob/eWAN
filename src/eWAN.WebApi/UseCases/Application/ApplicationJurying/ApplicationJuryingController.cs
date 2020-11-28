using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace eWAN.WebApi.UseCases.ApplicationJurying
{
    using Domains.Application;
    using Domains.User;
    using Application.UseCases;
    using Application.Boundaries.ApplicationJurying;
    using Microsoft.AspNetCore.Http;

    [Authorize]
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public sealed class ApplicationController : Controller
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ApplyJudgement(
            [FromServices] IApplicationJuryingUseCase useCase,
            [FromServices] ApplicationJuryingPresenter presenter,
            [FromServices] IApplicationRepository applicationRepository,
            [FromServices] IUserRepository userRepository,
            [FromForm] [Required] ApplicationJuryingRequest request
        )
        {
            var jury = await userRepository.GetByUsername(HttpContext.User.Identity.Name);
            var input = new ApplicationJuryingInput(
                request.ApplicationId,
                jury,
                request.IsAccepted,
                request.Reason);
            await useCase.Handle(input);
            return presenter.ViewModel;
        }
    }
}

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

    [Authorize]
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public sealed class ApplicationController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> ApplyJudgement(
            [FromServices] ApplicationJuryingUseCase useCase,
            [FromServices] ApplicationJuryingPresenter presenter,
            [FromServices] IApplicationRepository applicationRepository,
            [FromServices] IUserRepository userRepository,
            [FromForm] [Required] ApplicationJuryingRequest request
        )
        {
            var jury = await userRepository.GetByUsername(this.HttpContext.User.Identity.Name);
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

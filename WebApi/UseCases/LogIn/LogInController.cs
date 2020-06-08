using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace eWAN.WebApi.UseCases.LogIn
{
    using Application.Boundaries.LogIn;

    [Authorize]
    [Route("/api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LogIn(
            [FromServices] LogInPresenter presenter,
            [FromServices] ILogInUseCase logInUseCase,
            [FromForm] LogInRequest request
        )
        {
            var logInInput = new LogInInput(request.Username, request.Password);
            await logInUseCase.Handle(logInInput);
            return presenter.ViewModel;
        }
    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace eWAN.WebApi.UseCases.LogIn
{
    using System.Security.Claims;
    using Application.Boundaries.LogIn;

    [Authorize]
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
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

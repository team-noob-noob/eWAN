using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using eWAN.Application.Boundaries.LogIn;
using Microsoft.AspNetCore.Http;

namespace eWAN.WebApi.UseCases.LogIn
{
    [Obsolete("This route has been deprecated", true)]
    [Authorize]
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

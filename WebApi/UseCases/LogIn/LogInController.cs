using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace eWAN.WebApi.UseCases.LogIn
{
    using System.Security.Claims;
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
            
            // TODO: Move away from the controller class
            if(presenter.ViewModel is OkObjectResult) 
            {
                await this.HttpContext.SignInAsync(new ClaimsPrincipal(new [] { presenter.Identity }));
            }

            return presenter.ViewModel;
        }
    }
}

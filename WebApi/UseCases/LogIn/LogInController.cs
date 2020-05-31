using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace eWAN.WebApi.UseCases.LogIn
{
    using Application.Boundaries.LogIn;

    [Route("/api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
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

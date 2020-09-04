using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace eWAN.WebApi.UseCases.Register
{
    using Application.Boundaries.Register;
    using Microsoft.AspNetCore.Http;

    [Authorize]
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public sealed class UserController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUser(
            [FromServices] IRegisterUseCase registerUseCase,
            [FromServices] RegisterPresenter presenter,
            [FromForm] RegisterRequest request)
        {
            var registerInput = new RegisterInput(
                request.Username,
                request.Password,
                request.Email,
                request.PhoneNumber,
                request.FirstName,
                request.MiddleName,
                request.LastName,
                request.Address);
            await registerUseCase.Handle(registerInput);
            return presenter.ViewModel;
        }
    }
}

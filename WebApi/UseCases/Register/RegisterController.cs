using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace eWAN.WebApi.UseCases.Register
{
    using Application.Boundaries.Register;

    [Authorize]
    [Route("/api/[controller]")]
    [ApiController]
    public sealed class RegisterController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
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

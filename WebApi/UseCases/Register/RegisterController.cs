using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace eWAN.WebApi.UseCases.Register
{
    using Application.Boundaries.Register;

    [Route("/api/[controller]")]
    [ApiController]
    public sealed class RegisterController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(
            [FromServices] IRegisterUseCase registerUseCase,
            [FromServices] RegisterPresenter presenter,
            [FromForm] RegisterRequest request)
        {
            var registerInput = new RegisterInput(request.Username, request.Password);
            await registerUseCase.Handle(registerInput);
            return Accepted(new {Test = "Testing"});
        }
    }
}

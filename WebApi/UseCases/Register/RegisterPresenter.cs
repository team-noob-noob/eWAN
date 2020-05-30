using Microsoft.AspNetCore.Mvc;

namespace eWAN.WebApi.UseCases.Register
{
    using Application.Boundaries.Register;

    public sealed class RegisterPresenter : IRegisterOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void Standard(RegisterOutput output) => this.ViewModel = new CreatedAtRouteResult("Register", new {Username = output.newUser.Username});
        
        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(message);
    }
}

using Microsoft.AspNetCore.Mvc;

namespace eWAN.WebApi.UseCases.Register
{
    using Application.Boundaries.Register;

    public sealed class RegisterPresenter : IRegisterOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void Standard(RegisterOutput output) => ViewModel = new CreatedAtRouteResult("Register", new {Username = output.NewUser.Username});
        
        public void WriteError(string message) => ViewModel = new BadRequestObjectResult(new {Message = message});
    }
}

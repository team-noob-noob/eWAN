using Microsoft.AspNetCore.Mvc;

namespace eWAN.WebApi.UseCases.LogIn
{
    using Application.Boundaries.LogIn;

    public class LogInPresenter : ILogInOutputPort
    {
        public IActionResult ViewModel = new NoContentResult();

        public void Standard(LogInOutput output) => this.ViewModel = new CreatedAtRouteResult("LogIn", output);

        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(new {Message = message});
    }
}

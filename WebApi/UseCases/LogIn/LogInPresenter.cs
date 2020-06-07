using Microsoft.AspNetCore.Mvc;

namespace eWAN.WebApi.UseCases.LogIn
{
    using Application.Boundaries.LogIn;

    public class LogInPresenter : ILogInOutputPort
    {
        public IActionResult ViewModel = new NoContentResult();

        public void Standard(LogInOutput output)
        {
            string session = "TESTING = " + output.user.Username;

            this.ViewModel = new CreatedAtRouteResult("LogIn", new LogInReponse(session));
        }

        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(new {Message = message});
    }
}

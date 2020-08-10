using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eWAN.WebApi.UseCases.LogIn
{
    using Application.Boundaries.LogIn;
    using Infrastructure.Auth;

    public class LogInPresenter : ILogInOutputPort
    {
        public IActionResult ViewModel = new NoContentResult();
        public ClaimsIdentity Identity = null;

        public void Standard(LogInOutput output)
        {
            string secret = System.Environment.GetEnvironmentVariable("SERVER_KEY");

            var claims = new[] { new Claim(ClaimTypes.Name, output.user.Username) };
            var identity = new ClaimsIdentity(claims);

            string token = IdentityToken.GenerateJwtSecurityToken(identity, secret);

            this.ViewModel = new OkObjectResult(new LogInReponse(token));
            this.Identity = identity;
        }

        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(new {Message = message});
    }
}

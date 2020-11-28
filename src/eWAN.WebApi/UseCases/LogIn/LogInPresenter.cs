using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, output.User.Id.ToString()));
            foreach(var role in output.User.AssignedRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, ((int) role.UserRole).ToString()));
            }

            var identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

            string token = IdentityToken.GenerateJwtSecurityToken(identity, secret);

            ViewModel = new OkObjectResult(new LogInReponse(token));
            Identity = identity;
        }

        public void WriteError(string message) => ViewModel = new BadRequestObjectResult(new {Message = message});
    }
}

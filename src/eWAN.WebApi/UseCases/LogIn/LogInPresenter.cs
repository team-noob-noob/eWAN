using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace eWAN.WebApi.UseCases.LogIn
{
    using Application.Boundaries.LogIn;
    using Infrastructure.Auth;
    using Domains.Role;

    public class LogInPresenter : ILogInOutputPort
    {
        public IActionResult ViewModel = new NoContentResult();
        public ClaimsIdentity Identity = null;

        public void Standard(LogInOutput output)
        {
            string secret = System.Environment.GetEnvironmentVariable("SERVER_KEY");

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, output.user.Id));
            foreach(var role in output.user.AssignedRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, ((int) role.role).ToString()));
            }

            var identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

            string token = IdentityToken.GenerateJwtSecurityToken(identity, secret);

            this.ViewModel = new OkObjectResult(new LogInReponse(token));
            this.Identity = identity;
        }

        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(new {Message = message});
    }
}

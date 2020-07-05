using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace eWAN.WebApi.UseCases.LogIn
{
    using Application.Boundaries.LogIn;

    public class LogInPresenter : ILogInOutputPort
    {
        public IActionResult ViewModel = new NoContentResult();
        public ClaimsIdentity Identity = null;

        public void Standard(LogInOutput output)
        {
            string secret = System.Environment.GetEnvironmentVariable("SERVER_KEY");

            var claims = new[] { new Claim(ClaimTypes.Name, output.user.Username) };
            var identity = new ClaimsIdentity(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            this.ViewModel = new OkObjectResult(new LogInReponse(token));
            this.Identity = identity;
        }

        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(new {Message = message});
    }
}

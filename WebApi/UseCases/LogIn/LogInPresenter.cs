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

            string token = GenerateJwtSecurityToken(identity, secret);

            this.ViewModel = new OkObjectResult(new LogInReponse(token));
            this.Identity = identity;
        }

        // TODO: Move to a separate class
        private string GenerateJwtSecurityToken(ClaimsIdentity identity, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "Testing123", // TODO: Move to a config file
                Issuer = "Testing123", // TODO: Move to a config file
                Subject = identity,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }

        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(new {Message = message});
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eWAN.Core.Domains.OAuth;
using eWAN.WebAPIs.RequestBodyModels;

namespace eWAN.WebAPIs.Controllers
{
    [Route("login/OAuth")]
    [ApiController]
    public class ServerOAuthController : ControllerBase
    {
        private readonly JWTToken _token_generator;
        public ServerOAuthController(JWTToken TokenGenerator)
        {
            this._token_generator = TokenGenerator;

        }
        [HttpPost]
        public ActionResult<AccessToken> GenerateAccessToken(LogIn login)
        {
            AccessToken token = new AccessToken();
            token.token_type = "Bearer";
            token.access_token = this._token_generator.createNewToken(login.name, login.access_permission);
            return token;
        }
    }
}
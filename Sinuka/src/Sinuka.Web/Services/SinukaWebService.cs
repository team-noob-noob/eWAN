using Refit;
using Sinuka.Web.Interfaces;
using Sinuka.Web.Endpoints;
using Sinuka.Web.ValueObjects;
using Sinuka.Core.Infrastructure.Configs;

namespace Sinuka.Web.Services
{
    public class SinukaWebService : ISinukaWebService
    {
        private readonly ISinukaWebEndpoint _sinukaWebEndpoint;

        public SinukaWebService(string baseUrl = null)
        {
            this._sinukaWebEndpoint = RestService.For<ISinukaWebEndpoint>(baseUrl ?? HostConfig.IdentityServerUrl);
        }

        public Token Authenticate(ClientCredentialsTokenRequest request)
        {
            return this._sinukaWebEndpoint.Authenticate(request);
        }
    }
}

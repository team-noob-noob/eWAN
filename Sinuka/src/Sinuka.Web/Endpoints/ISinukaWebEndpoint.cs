using Refit;
using Sinuka.Web.ValueObjects;

namespace Sinuka.Web.Endpoints
{
    public interface ISinukaWebEndpoint
    {
        [Post("/connect/token")]
        Token Authenticate([Body(BodySerializationMethod.UrlEncoded)]ClientCredentialsTokenRequest request);
    }
}

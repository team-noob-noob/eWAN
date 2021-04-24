using Sinuka.Web.ValueObjects;

namespace Sinuka.Web.Interfaces
{
    public interface ISinukaWebService
    {
        Token Authenticate(ClientCredentialsTokenRequest request);
    }
}

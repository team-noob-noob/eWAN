namespace Sinuka.Web.ValueObjects
{
    public class ClientCredentialsTokenRequest
    {
        public string GrantType { get; set; }
        public string Scope { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}

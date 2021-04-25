using Newtonsoft.Json;

namespace Sinuka.Web.ValueObjects
{
    public class ClientCredentialsTokenRequest
    {
        [JsonProperty("grant_type")]
        public string GrantType { get; set; }
        
        [JsonProperty("scope")]
        public string Scope { get; set; }
        
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
        
        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }
    }
}

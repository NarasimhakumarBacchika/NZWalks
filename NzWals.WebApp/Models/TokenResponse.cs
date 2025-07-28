using System.Text.Json.Serialization;

namespace NzWals.WebApp.Models
{
    public class TokenResponse
    {
        [JsonPropertyName("jwtToken")]
        public string Token { get; set; }
    }
}

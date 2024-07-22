using Newtonsoft.Json;

namespace DummyJsonTests.Schemas;

public class RefreshSchema
{
    [JsonProperty("refreshToken")]
    public string RefreshToken { get; set; }

    [JsonProperty("expiresInMins")]
    public int ExpiresInMins { get; set; }
    
    public RefreshSchema(string refreshToken, int expiresInMins = 30)
    {
        RefreshToken = refreshToken;
        ExpiresInMins = expiresInMins;
    }
}
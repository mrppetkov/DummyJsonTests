using Newtonsoft.Json;

namespace DummyJsonTests.Models;

public class BaseUser
{
    [JsonProperty("username")]
    public string Username { get; set; }
    
    [JsonProperty("password")]
    public string Password { get; set; }
    
    public string ToJson() => JsonConvert.SerializeObject(this);
}
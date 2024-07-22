using Newtonsoft.Json;

namespace DummyJsonTests.Models;

public class Hair
{
    [JsonProperty("color")]
    public string Color { get; set; }
    
    [JsonProperty("type")]
    public string Type { get; set; }
}
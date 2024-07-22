using Newtonsoft.Json;

namespace DummyJsonTests.Models;

public class Coordinates
{
    [JsonProperty("lat")]
    public double Lat { get; set; }
    
    [JsonProperty("lng")]
    public double Lng { get; set; }
}
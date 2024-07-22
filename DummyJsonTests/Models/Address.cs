using Newtonsoft.Json;

namespace DummyJsonTests.Models;

public class Address
{
    [JsonProperty("address")]
    public string Address1 { get; set; }
    
    [JsonProperty("city")]
    public string City { get; set; }
    
    [JsonProperty("state")]
    public string State { get; set; }
    
    [JsonProperty("stateCode")]
    public string StateCode { get; set; }
    
    [JsonProperty("postalCode")]
    public string PostalCode { get; set; }
    
    [JsonProperty("coordinates")]
    public Coordinates Coordinates { get; set; }
    
    [JsonProperty("country")]
    public string Country { get; set; }
}
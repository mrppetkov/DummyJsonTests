using Newtonsoft.Json;

namespace DummyJsonTests.Models;

public class Company
{
    [JsonProperty("department")]
    public string Department { get; set; }
  
    [JsonProperty("name")]
    public string Name { get; set; }
  
    [JsonProperty("title")]
    public string Title { get; set; }
  
    [JsonProperty("address")]
    public Address Address { get; set; }
}
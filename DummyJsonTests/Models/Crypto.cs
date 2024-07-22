using Newtonsoft.Json;

namespace DummyJsonTests.Models;

public class Crypto
{
    [JsonProperty("coin")]
    public string Coin { get; set; }
  
    [JsonProperty("wallet")]
    public string Wallet { get; set; }
  
    [JsonProperty("network")]
    public string Network { get; set; }
}
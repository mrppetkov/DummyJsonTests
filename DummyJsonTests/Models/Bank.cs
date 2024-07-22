using Newtonsoft.Json;

namespace DummyJsonTests.Models;

public class Bank
{
    [JsonProperty("cardExpire")]
    public string CardExpire { get; set; }
  
    [JsonProperty("cardNumber")]
    public string CardNumber { get; set; }
  
    [JsonProperty("cardType")]
    public string CardType { get; set; }
  
    [JsonProperty("currency")]
    public string Currency { get; set; }
  
    [JsonProperty("iban")]
    public string Iban { get; set; }
}
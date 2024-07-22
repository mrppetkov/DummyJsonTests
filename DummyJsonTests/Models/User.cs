using Newtonsoft.Json;

namespace DummyJsonTests.Models;

public class User : BaseUser
{
    [JsonProperty("id")]
    public long Id { get; set; }
    
    [JsonProperty("firstName")]
    public string FirstName { get; set; }
    
    [JsonProperty("lastName")]
    public string LastName { get; set; }
    
    [JsonProperty("maidenName")]
    public string MaidenName { get; set; }
    
    [JsonProperty("age")]
    public long Age { get; set; }
    
    [JsonProperty("gender")]
    public Gender Gender { get; set; }
    
    [JsonProperty("email")]
    public string Email { get; set; }
    
    [JsonProperty("phone")]
    public string Phone { get; set; }
    
    [JsonProperty("birthDate")]
    public string BirthDate { get; set; }
    
    [JsonProperty("image")]
    public Uri Image { get; set; }
    
    [JsonProperty("bloodGroup")]
    public string BloodGroup { get; set; }
    
    [JsonProperty("height")]
    public double Height { get; set; }
    
    [JsonProperty("weight")]
    public double Weight { get; set; }
    
    [JsonProperty("eyeColor")]
    public string EyeColor { get; set; }
    
    [JsonProperty("hair")]
    public Hair Hair { get; set; }
    
    [JsonProperty("ip")]
    public string Ip { get; set; }
    
    [JsonProperty("address")]
    public Address Address { get; set; }
    
    [JsonProperty("macAddress")]
    public string MacAddress { get; set; }
    
    [JsonProperty("university")]
    public string University { get; set; }
    
    [JsonProperty("bank")]
    public Bank Bank { get; set; }
    
    [JsonProperty("company")]
    public Company Company { get; set; }
    
    [JsonProperty("ein")]
    public string Ein { get; set; }
    
    [JsonProperty("ssn")]
    public string Ssn { get; set; }
    
    [JsonProperty("userAgent")]
    public string UserAgent { get; set; }
    
    [JsonProperty("crypto")]
    public Crypto Crypto { get; set; }
    
    [JsonProperty("role")]
    public string Role { get; set; }
    
    public string FullName => $"{FirstName} {LastName}";
    
    public string FullAddress => $"{Address.Address1}, {Address.City}, {Address.State}, {Address.Country}";
    
    public string FullCompanyAddress => $"{Company.Address.Address1}, {Company.Address.City}, {Company.Address.State}, {Company.Address.Country}";
    
    public string FullBankInfo => $"{Bank.CardType} - {Bank.CardNumber}";
    
    public string FullCryptoInfo => $"{Crypto.Coin} - {Crypto.Wallet}";
}
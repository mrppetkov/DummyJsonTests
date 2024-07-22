using Newtonsoft.Json;
using DummyJsonTests.Models;

namespace DummyJsonTests.Responses;

public class LoginResponse
{
    [JsonProperty("id")]
    public long Id { get; set; }
    
    [JsonProperty("username")]
    public string Username { get; set; }
    
    [JsonProperty("email")]
    public string Email { get; set; }
    
    [JsonProperty("firstName")]
    public string FirstName { get; set; }
    
    [JsonProperty("lastName")]
    public string LastName { get; set; }
    
    [JsonProperty("gender")]
    public Gender Gender { get; set; }
    
    [JsonProperty("image")]
    public Uri Image { get; set; }
    
    [JsonProperty("token")]
    public string Token { get; set; }
    
    [JsonProperty("refreshToken")]
    public string RefreshToken { get; set; }
}
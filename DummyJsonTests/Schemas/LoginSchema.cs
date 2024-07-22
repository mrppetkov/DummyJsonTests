using Newtonsoft.Json;
using DummyJsonTests.Models;

namespace DummyJsonTests.Schemas;

public class LoginSchema : BaseUser
{
    [JsonProperty("expiresInMins")]
    public int ExpiresInMins { get; set; }
    
    public LoginSchema(string username, string password, int expiresInMins)
    {
        Username = username;
        Password = password;
        ExpiresInMins = expiresInMins;
    }
}
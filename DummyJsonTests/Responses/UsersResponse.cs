using Newtonsoft.Json;
using DummyJsonTests.Models;

namespace DummyJsonTests.Responses;

public class UsersResponse
{
    [JsonProperty("users")]
    public required User[] Users { get; set; }
}

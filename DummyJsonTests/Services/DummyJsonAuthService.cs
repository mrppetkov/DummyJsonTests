using System.Text;
using Newtonsoft.Json;
using DummyJsonTests.Responses;
using DummyJsonTests.Schemas;

namespace DummyJsonTests.Services;

public class DummyJsonAuthService : IDisposable
{
    private HttpClient _httpClient;
    private const string BaseUrl = "https://dummyjson.com/";
    private const string AuthNamespace = "auth";
    private const string LoginEndpoint = "login";
    private const string RefreshEndpoint = "refresh";
    
    public DummyJsonAuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(BaseUrl);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
    
    public async Task<LoginResponse> LoginAsync(LoginSchema loginSchema)
    {
        var content = new StringContent(loginSchema.ToJson(), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{AuthNamespace}/{LoginEndpoint}", content);
        var responseString = await response.Content.ReadAsStringAsync();
        
        // Throws exception if response is not successful
        response.EnsureSuccessStatusCode();
        
        return JsonConvert.DeserializeObject<LoginResponse>(responseString) ?? throw new InvalidOperationException();
    }
    
    public async Task<LoginResponse> RefreshTokenAsync(string refreshToken, int expiresInMins = 60)
    {
        var refreshRequest = new RefreshSchema(refreshToken, expiresInMins);

        var content = new StringContent(JsonConvert.SerializeObject(refreshRequest), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{AuthNamespace}/{RefreshEndpoint}", content);
        var responseString = await response.Content.ReadAsStringAsync();
        
        response.EnsureSuccessStatusCode();
        
        return JsonConvert.DeserializeObject<LoginResponse>(responseString) ?? throw new InvalidOperationException();
    }
}
using Newtonsoft.Json;
using DummyJsonTests.Models;
using DummyJsonTests.Responses;

namespace DummyJsonTests.Services;

public class DummyJsonCurrentUserService : IDisposable
{
    private HttpClient _httpClient;
    private const string BaseUrl = "https://dummyjson.com/";
    private const string AuthNamespace = "auth";
    private const string MeEndpoint = "me";
    private LoginResponse _user;
    
    public DummyJsonCurrentUserService(HttpClient httpClient, LoginResponse user)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(BaseUrl);
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", user.Token);
        _user = user;
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
    
    public async Task<User> GetCurrentUserAsync()
    {
        var response = await _httpClient.GetAsync($"{AuthNamespace}/{MeEndpoint}");
        var responseString = await response.Content.ReadAsStringAsync();
        
        response.EnsureSuccessStatusCode();
        
        return JsonConvert.DeserializeObject<User>(responseString) ?? throw new InvalidOperationException();
    }
}
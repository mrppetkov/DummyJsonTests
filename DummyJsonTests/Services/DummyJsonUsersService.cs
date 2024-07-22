using Newtonsoft.Json;
using DummyJsonTests.Models;
using DummyJsonTests.Responses;

namespace DummyJsonTests.Services;

public class DummyJsonUsersService : IDisposable
{
    private HttpClient _httpClient;
    private const string UsersEndpoint = "users";
    private const string BaseUrl = "https://dummyjson.com/";
    
    public DummyJsonUsersService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(BaseUrl);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
    
    public async Task<User> GetUserAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{UsersEndpoint}/{id}");
        var responseString = await response.Content.ReadAsStringAsync();
        
        response.EnsureSuccessStatusCode();
        
        return JsonConvert.DeserializeObject<User>(responseString) ?? throw new InvalidOperationException();
    }
    
    public async Task<UsersResponse> GetUsersAsync()
    {
        var response = await _httpClient.GetAsync(UsersEndpoint);
        var responseString = await response.Content.ReadAsStringAsync();
        
        response.EnsureSuccessStatusCode();
        
        return JsonConvert.DeserializeObject<UsersResponse>(responseString) ?? throw new InvalidOperationException();
    }
}
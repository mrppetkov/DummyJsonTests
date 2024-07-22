using System.Diagnostics;
using System.Net;
using DummyJsonTests.Schemas;
using DummyJsonTests.Services;

namespace DummyJsonTests;

public class AuthTests
{
    private DummyJsonAuthService _authService;
    private const string Username = "emilys";
    private const string Password = "emilyspass";

    
    [SetUp]
    public void Setup()
    {
        // Initialize HttpClient
        var httpClient = new HttpClient();
        // Initialize DummyJsonService
        _authService = new DummyJsonAuthService(httpClient);
    }
    
    [TearDown]
    public void TearDown()
    {
        // Dispose the service
        _authService.Dispose();
    }
    
    [Test]
    public void LoginTestSuccess()
    {
        // Arrange
        var loginRequestData = new LoginSchema(Username, Password, 60);
        
        // Act
        var loginResponse = _authService.LoginAsync(loginRequestData).Result;
        
        // Assert
        Debug.Assert(loginResponse != null, nameof(loginResponse) + " != null");
        Assert.That(loginResponse.Username, Is.EqualTo(Username));
        Assert.That(loginResponse.Token, Is.Not.Null);
        Assert.That(loginResponse.RefreshToken, Is.Not.Null);
    }
    
    [TestCase("emilys", "wrongpass")]
    [TestCase("wronguser", "emilyspass")]
    public void LoginTestFail(string username, string password)
    {
        // Arrange
        var loginRequestData = new LoginSchema(username, password, 60);
        
        // Act & Assert throws 400
        HttpRequestException ex = Assert.ThrowsAsync<HttpRequestException>(() => _authService.LoginAsync(loginRequestData));
        
        Assert.That(ex.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }
    
    [Test]
    public void RefreshTokenTest()
    {
        // Arrange
        var loginRequestData = new LoginSchema(Username, Password, 60);

        // Act
        var loginResponse = _authService.LoginAsync(loginRequestData).Result;
        var refreshResponse = _authService.RefreshTokenAsync(loginResponse.RefreshToken, 30).Result;

        // Assert
        Debug.Assert(refreshResponse != null, nameof(refreshResponse) + " != null");
        Assert.That(refreshResponse.Token, Is.Not.Null);
        Assert.That(refreshResponse.RefreshToken, Is.Not.Null);
    }
}
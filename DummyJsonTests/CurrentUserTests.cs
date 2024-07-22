using System.Diagnostics;
using DummyJsonTests.Responses;
using DummyJsonTests.Schemas;
using DummyJsonTests.Services;

namespace DummyJsonTests;

public class CurentUserTests
{
    private const string Username = "emilys";
    private const string Password = "emilyspass";
    private DummyJsonCurrentUserService _currentUserService;
    private DummyJsonAuthService _authService;

    
    [SetUp]
    public void Setup()
    {
        // Initialize HttpClient
        var AuthHttpClient = new HttpClient();
        var CurrentUserHttpClient = new HttpClient();
        // Initialize DummyJsonService
        _authService = new DummyJsonAuthService(AuthHttpClient);
        LoginResponse currentUser = _authService.LoginAsync(new LoginSchema(Username, Password, 60)).Result;
        _currentUserService = new DummyJsonCurrentUserService(CurrentUserHttpClient, currentUser);
    }
    
    [TearDown]
    public void TearDown()
    {
        // Dispose the service
        _currentUserService.Dispose();
        _authService.Dispose();
    }

    [Test]
    public void GetCurrentUserTest()
    {
        // Act
        var currentUser = _currentUserService.GetCurrentUserAsync().Result;

        // Assert
        Debug.Assert(currentUser != null, nameof(currentUser) + " != null");
        Assert.That(currentUser.Username, Is.EqualTo(Username));
    }
}
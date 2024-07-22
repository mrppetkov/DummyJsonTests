using System.Diagnostics;
using System.Net;
using DummyJsonTests.Services;

namespace DummyJsonTests;

public class UsersTests
{
    private DummyJsonUsersService _usersService;

    
    [SetUp]
    public void Setup()
    {
        // Initialize HttpClient
        var httpClient = new HttpClient();
        // Initialize DummyJsonService
        _usersService = new DummyJsonUsersService(httpClient);
    }
    
    [TearDown]
    public void TearDown()
    {
        // Dispose the service
        _usersService.Dispose();
    }
    
    [Test]
    public void GetUserTestFail()
    {
        // Act & Assert throws 404
        HttpRequestException ex = Assert.ThrowsAsync<HttpRequestException>(() => _usersService.GetUserAsync(0));
        
        Assert.That(ex.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        Assert.That(ex.Message, Does.Contain("404"));
        
    }

    [Test]
    public void GetUserTest()
    {
        // Act
        var loadedUser = _usersService.GetUserAsync(1).Result;
        
        // Assert
        Debug.Assert(loadedUser != null, nameof(loadedUser) + " != null");
        Assert.That(loadedUser.Id, Is.EqualTo(1));
    }
    
    [Test]
    public void GetUsersTest()
    {
        // Act
        var loadedUsers = _usersService.GetUsersAsync().Result;
        
        // Assert
        Debug.Assert(loadedUsers != null, nameof(loadedUsers) + " != null");
        Assert.That(loadedUsers.Users.Count, Is.GreaterThan(0));
        Assert.That(loadedUsers.Users.Any(u => u.FirstName == "Emily"));
    }
}
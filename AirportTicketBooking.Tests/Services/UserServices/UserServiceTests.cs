using AirportTicketBooking.Interfaces.Repositories;
using AirportTicketBooking.Models;
using AirportTicketBooking.Services;
using AirportTicketBooking.Tests.Services.UserService;
using Moq;

namespace AirportTicketBooking.Tests;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _mockRepo;
    private readonly UserService _service;

    public UserServiceTests()
    {
        _mockRepo = new Mock<IUserRepository>();
        _service = new UserService(_mockRepo.Object);
    }

    [Theory]
    [ClassData(typeof(UserTestData))]
    public async Task AddAsync_Should(User user)
    {
        _mockRepo.Setup(r => r.AddAsync(user)).ReturnsAsync(user.UserId);

        var result = await _service.AddAsync(user);

        Assert.Equal(user.UserId, result);
        _mockRepo.Verify(r => r.AddAsync(user), Times.Once);
    }

    [Fact]
    public async Task GetByIdAsync_Should()
    {
        var userId = "user1";

        _mockRepo.Setup(r => r.GetByIdAsync(userId)).ReturnsAsync((User?)null);

        var result = await _service.GetByIdAsync(userId);

        _mockRepo.Verify(r => r.GetByIdAsync(userId), Times.Once);
        Assert.Null(result);
    }

    [Fact]
    public async Task GetByEmailAsync_Should()
    {
        var email = "user@gmail.com";

        _mockRepo.Setup(r => r.GetByEmailAsync(email)).ReturnsAsync((User?)null);

        var result = await _service.GetByEmailAsync(email);

        _mockRepo.Verify(r => r.GetByEmailAsync(email), Times.Once);
        Assert.Null(result);
    }


    [Theory]
    [ClassData(typeof(GetAllUsersTestData))]
    public async Task GetAllAsync_Should(IEnumerable<User> expectedUsers)
    {
        _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(expectedUsers);

        var result = await _service.GetAllAsync();

        Assert.Equal(expectedUsers, result);
    }

    [Fact]
    public async Task DeleteAsync_Should()
    {
        var userId = "user1";

        _mockRepo.Setup(r => r.DeleteAsync(userId)).ReturnsAsync(true);

        var result = await _service.DeleteAsync(userId);

        Assert.True(result);
        _mockRepo.Verify(r => r.DeleteAsync(userId), Times.Once);
    }


    [Theory]
    [ClassData(typeof(UserTestData))]
    public async Task UpdateAsync_Should_Call_Repository(User user)
    {
        _mockRepo.Setup(r => r.UpdateAsync(user)).ReturnsAsync(true);

        var result = await _service.UpdateAsync(user);

        Assert.True(result);
        _mockRepo.Verify(r => r.UpdateAsync(user), Times.Once);
    }

    [Theory]
    [ClassData(typeof(AuthenticationTestData))]
    public async Task UserAuthentication_Should_Return_User_If_Valid(string userId, string password, User? expectedUser)
    {
        _mockRepo.Setup(r => r.GetByIdAsync(userId)).ReturnsAsync(expectedUser);

        var result = await _service.UserAuthentication(userId, password);

        Assert.Equal(expectedUser, result);
    }
}
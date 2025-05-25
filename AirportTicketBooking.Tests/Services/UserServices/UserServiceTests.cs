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
    public async Task AddAsync_ValidUser_ReturnsUserId(User user)
    {
        // Arrange
        _mockRepo.Setup(r => r.AddAsync(user)).ReturnsAsync(user.UserId);

        // Act
        var result = await _service.AddAsync(user);

        // Assert
        _mockRepo.Verify(r => r.AddAsync(user), Times.Once);
        Assert.Equal(user.UserId, result);
    }

    [Fact]
    public async Task GetByIdAsync_UserDoesNotExist_ReturnsNull()
    {
        // Arrange
        var userId = "user1";
        _mockRepo.Setup(r => r.GetByIdAsync(userId)).ReturnsAsync((User?)null);

        // Act
        var result = await _service.GetByIdAsync(userId);

        // Assert
        _mockRepo.Verify(r => r.GetByIdAsync(userId), Times.Once);
        Assert.Null(result);
    }

    [Fact]
    public async Task GetByEmailAsync_EmailDoesNotExist_ReturnsNull()
    {
        // Arrange
        var email = "user@gmail.com";
        _mockRepo.Setup(r => r.GetByEmailAsync(email)).ReturnsAsync((User?)null);

        // Act
        var result = await _service.GetByEmailAsync(email);

        // Assert
        _mockRepo.Verify(r => r.GetByEmailAsync(email), Times.Once);
        Assert.Null(result);
    }

    [Theory]
    [ClassData(typeof(GetAllUsersTestData))]
    public async Task GetAllAsync_UsersExist_ReturnsUserList(IEnumerable<User> expectedUsers)
    {
        // Arrange
        _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(expectedUsers);

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        Assert.Equal(expectedUsers, result);
    }

    [Fact]
    public async Task DeleteAsync_ValidUserId_ReturnsTrue()
    {
        // Arrange
        var userId = "user1";
        _mockRepo.Setup(r => r.DeleteAsync(userId)).ReturnsAsync(true);

        // Act
        var result = await _service.DeleteAsync(userId);

        // Assert
        _mockRepo.Verify(r => r.DeleteAsync(userId), Times.Once);
        Assert.True(result);
    }

    [Theory]
    [ClassData(typeof(UserTestData))]
    public async Task UpdateAsync_ValidUser_CallsRepository(User user)
    {
        // Arrange
        _mockRepo.Setup(r => r.UpdateAsync(user)).ReturnsAsync(true);

        // Act
        var result = await _service.UpdateAsync(user);

        // Assert
        _mockRepo.Verify(r => r.UpdateAsync(user), Times.Once);
        Assert.True(result);
    }

    [Theory]
    [ClassData(typeof(AuthenticationTestData))]
    public async Task UserAuthentication_ValidCredentials_ReturnsUser(string userId, string password, User? expectedUser)
    {
        // Arrange
        _mockRepo.Setup(r => r.GetByIdAsync(userId)).ReturnsAsync(expectedUser);

        // Act
        var result = await _service.UserAuthentication(userId, password);

        // Assert
        Assert.Equal(expectedUser, result);
    }
}

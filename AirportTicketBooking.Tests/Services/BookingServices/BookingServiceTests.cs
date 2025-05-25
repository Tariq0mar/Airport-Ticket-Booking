using AirportTicketBooking.Interfaces.Repositories;
using AirportTicketBooking.Interfaces.Services;
using AirportTicketBooking.Models;
using AirportTicketBooking.Services;
using Moq;

namespace AirportTicketBooking.Tests.Services
{
    public class BookingServiceTests
    {
        private readonly Mock<IBookingRepository> _mockRepo;
        private readonly IBookingService _service;

        public BookingServiceTests()
        {
            _mockRepo = new Mock<IBookingRepository>();
            _service = new BookingService(_mockRepo.Object);
        }

        [Fact]
        public async Task AddAsync_ValidBooking_ReturnsBookingId()
        {
            // Arrange
            var booking = new Booking { Id = "b1", FlightId = "f1", PassengerId = "p1" };
            _mockRepo.Setup(r => r.AddAsync(booking)).ReturnsAsync(booking.Id);

            // Act
            var result = await _service.AddAsync(booking);

            // Assert
            _mockRepo.Verify(r => r.AddAsync(booking), Times.Once);
            Assert.Equal("b1", result);
        }

        [Fact]
        public async Task GetByBookingIdAsync_BookingNotFound_ReturnsNull()
        {
            // Arrange
            var bookingId = "b1";
            _mockRepo.Setup(r => r.GetByBookingIdAsync(bookingId)).ReturnsAsync((Booking?)null);

            // Act
            var result = await _service.GetByBookingIdAsync(bookingId);

            // Assert
            _mockRepo.Verify(r => r.GetByBookingIdAsync(bookingId), Times.Once);
            Assert.Null(result);
        }

        [Fact]
        public async Task GetByPassengerIdAsync_ValidId_ReturnsBookings()
        {
            // Arrange
            var passengerId = "p1";
            var expectedBookings = new List<Booking>
            {
                new Booking { Id = "b1", FlightId = "f1", PassengerId = "p1" },
                new Booking { Id = "b2", FlightId = "f2", PassengerId = "p1" }
            };
            _mockRepo.Setup(r => r.GetByPassengerIdAsync(passengerId)).ReturnsAsync(expectedBookings);

            // Act
            var result = await _service.GetByPassengerIdAsync(passengerId);

            // Assert
            _mockRepo.Verify(r => r.GetByPassengerIdAsync(passengerId), Times.Once);
            Assert.Equal(expectedBookings, result);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllBookings()
        {
            // Arrange
            var expectedBookings = new List<Booking>
            {
                new Booking { Id = "b1", FlightId = "f1", PassengerId = "p1" },
                new Booking { Id = "b2", FlightId = "f2", PassengerId = "p2" }
            };
            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(expectedBookings);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            _mockRepo.Verify(r => r.GetAllAsync(), Times.Once);
            Assert.Equal(expectedBookings, result);
        }

        [Fact]
        public async Task DeleteAsync_ValidId_ReturnsTrue()
        {
            // Arrange
            var bookingId = "b1";
            _mockRepo.Setup(r => r.DeleteAsync(bookingId)).ReturnsAsync(true);

            // Act
            var result = await _service.DeleteAsync(bookingId);

            // Assert
            _mockRepo.Verify(r => r.DeleteAsync(bookingId), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public async Task UpdateAsync_ValidBooking_ReturnsTrue()
        {
            // Arrange
            var booking = new Booking { Id = "b1", FlightId = "f1", PassengerId = "p1" };
            _mockRepo.Setup(r => r.UpdateAsync(booking)).ReturnsAsync(true);

            // Act
            var result = await _service.UpdateAsync(booking);

            // Assert
            _mockRepo.Verify(r => r.UpdateAsync(booking), Times.Once);
            Assert.True(result);
        }
    }
}

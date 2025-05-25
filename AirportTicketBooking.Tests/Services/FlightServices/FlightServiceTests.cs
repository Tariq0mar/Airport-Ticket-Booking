using AirportTicketBooking.Enums;
using AirportTicketBooking.Interfaces.Repositories;
using AirportTicketBooking.Models;
using AirportTicketBooking.Services;
using Moq;

namespace AirportTicketBooking.Tests;

public class FlightServiceTests
{
    private readonly Mock<IFlightRepository> _mockRepo;
    private readonly FlightService _service;

    public FlightServiceTests()
    {
        _mockRepo = new Mock<IFlightRepository>();
        _service = new FlightService(_mockRepo.Object);
    }

    [Fact]
    public async Task AddAsync_ValidFlight_ReturnsFlightId()
    {
        // Arrange
        var flight = new Flight
        {
            FlightId = "F1",
            DepartureData = new TravelData
            {
                LocationCountry = Country.Palestine,
                FlightAirport = Airport.LAX,
                FlightDate = new DateTime(2025, 6, 1)
            },
            DestinationData = new TravelData
            {
                LocationCountry = Country.Palestine,
                FlightAirport = Airport.LAX,
                FlightDate = new DateTime(2025, 6, 1, 20, 0, 0)
            },
            ClassPrice = new Dictionary<FlightClass, float>
            {
                { FlightClass.Economy, 250.0f },
                { FlightClass.Business, 800.0f }
            }
        };

        _mockRepo.Setup(r => r.AddAsync(flight)).ReturnsAsync(flight.FlightId);

        // Act
        var result = await _service.AddAsync(flight);

        // Assert
        Assert.Equal(flight.FlightId, result);
        _mockRepo.Verify(r => r.AddAsync(flight), Times.Once);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsListOfFlights()
    {
        // Arrange
        var flights = new List<Flight>
        {
            new Flight
            {
                FlightId = "F2",
                DepartureData = new TravelData
                {
                    LocationCountry = Country.Palestine,
                    FlightAirport = Airport.LAX,
                    FlightDate = new DateTime(2025, 7, 15)
                },
                DestinationData = new TravelData
                {
                    LocationCountry = Country.Palestine,
                    FlightAirport = Airport.LAX,
                    FlightDate = new DateTime(2025, 7, 15, 18, 0, 0)
                },
                ClassPrice = new Dictionary<FlightClass, float>
                {
                    { FlightClass.Economy, 120.0f },
                    { FlightClass.PremiumEconomy, 180.0f }
                }
            }
        };

        _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(flights);

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        Assert.Equal(flights, result);
        _mockRepo.Verify(r => r.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task GetByIdAsync_FlightExists_ReturnsFlight()
    {
        // Arrange
        var flightId = "F3";
        var flight = new Flight
        {
            FlightId = flightId,
            DepartureData = new TravelData
            {
                LocationCountry = Country.Palestine,
                FlightAirport = Airport.LAX,
                FlightDate = new DateTime(2025, 8, 10)
            },
            DestinationData = new TravelData
            {
                LocationCountry = Country.Palestine,
                FlightAirport = Airport.LAX,
                FlightDate = new DateTime(2025, 8, 10, 15, 0, 0)
            },
            ClassPrice = new Dictionary<FlightClass, float>
            {
                { FlightClass.Economy, 130.0f },
                { FlightClass.FirstClass, 1000.0f }
            }
        };

        _mockRepo.Setup(r => r.GetByIdAsync(flightId)).ReturnsAsync(flight);

        // Act
        var result = await _service.GetByIdAsync(flightId);

        // Assert
        Assert.Equal(flight, result);
        _mockRepo.Verify(r => r.GetByIdAsync(flightId), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ValidFlight_ReturnsTrue()
    {
        // Arrange
        var flight = new Flight
        {
            FlightId = "F4",
            DepartureData = new TravelData
            {
                LocationCountry = Country.Palestine,
                FlightAirport = Airport.LAX,
                FlightDate = new DateTime(2025, 9, 5)
            },
            DestinationData = new TravelData
            {
                LocationCountry = Country.Palestine,
                FlightAirport = Airport.LAX,
                FlightDate = new DateTime(2025, 9, 5, 10, 0, 0)
            },
            ClassPrice = new Dictionary<FlightClass, float>
            {
                { FlightClass.Business, 700.0f },
                { FlightClass.Economy, 300.0f }
            }
        };

        _mockRepo.Setup(r => r.UpdateAsync(flight)).ReturnsAsync(true);

        // Act
        var result = await _service.UpdateAsync(flight);

        // Assert
        Assert.True(result);
        _mockRepo.Verify(r => r.UpdateAsync(flight), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ValidId_ReturnsTrue()
    {
        // Arrange
        var flightId = "F5";
        _mockRepo.Setup(r => r.DeleteAsync(flightId)).ReturnsAsync(true);

        // Act
        var result = await _service.DeleteAsync(flightId);

        // Assert
        Assert.True(result);
        _mockRepo.Verify(r => r.DeleteAsync(flightId), Times.Once);
    }
}

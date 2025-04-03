using AirportTicketBooking.Models;
using AirportTicketBooking.Convert;
using AirportTicketBooking.Interfaces.Repositories;

namespace AirportTicketBooking.Repositories;

public class FlightRepository : IFlightRepository
{
    private readonly string _filePath = "D:\\Airport-Ticket-Flight\\AirportTicketFlight\\DataBase\\flights.csv";
    private static int _idCounter = 0;

    public async Task AddFlightAsync(Flight flight)
    {
        flight.FlightId = (++_idCounter).ToString("D11");
        var line = $"{flight}{Environment.NewLine}";
        await File.AppendAllTextAsync(_filePath, line);
    }

    public async Task<Flight?> GetFlightByIdAsync(string id)
    {
        var Flights = await GetAllFlightsAsync();
        return Flights.FirstOrDefault(b => b.FlightId == id);
    }

    public async Task<IEnumerable<Flight>> GetAllFlightsAsync()
    {
        var lines = await File.ReadAllLinesAsync(_filePath);
        var flightList = new List<Flight>();

        foreach (var line in lines)
        {
            flightList.Add(ConvertFromCsv.ToFlight(line));
        }

        return flightList;
    }

    public async Task UpdateFlightAsync(Flight newFlight)
    {
        var flights = (await GetAllFlightsAsync()).ToList();
        var index = flights.FindIndex(b => b.FlightId == newFlight.FlightId);

        if (index != -1)
        {
            flights[index] = newFlight;
            await SaveAllFlightsAsync(flights);
        }
    }

    public async Task DeleteFlightAsync(string id)
    {
        var Flights = (await GetAllFlightsAsync()).Where(b => b.FlightId != id).ToList();
        await SaveAllFlightsAsync(Flights);
    }

    private async Task SaveAllFlightsAsync(IEnumerable<Flight> flights)
    {
        var lines = new List<string>(flights.Select(f => $"{f}"));
        await File.WriteAllLinesAsync(_filePath, lines);
    }
}

using AirportTicketBooking.Models;
using AirportTicketBooking.Convert;
using AirportTicketBooking.Interfaces.Repositories;
using AirportTicketBooking.Serializers;

namespace AirportTicketBooking.Repositories;

public class FlightRepository : IFlightRepository
{
    private readonly string _filePath = Path.GetFullPath(Path.Combine("..", "..", "..", "DataBase", "flights.csv"));
    private static int _idCounter = 0;

    public async Task AddAsync(Flight flight)
    {
        var line = $"{ConvertToCsv.FromFlight(flight)}{Environment.NewLine}";
        var parts = line.Split(',');
        parts[0] = (++_idCounter).ToString("D11");
        line = string.Join(",", parts);

        await File.AppendAllTextAsync(_filePath, line);
    }

    public async Task<Flight?> GetByIdAsync(string id)
    {
        var Flights = await GetAllAsync();
        return Flights.FirstOrDefault(b => b.FlightId == id);
    }

    public async Task<IEnumerable<Flight>> GetAllAsync()
    {
        var lines = await File.ReadAllLinesAsync(_filePath);
        var flightList = new List<Flight>();

        foreach (var line in lines)
        {
            var lineFlight = ConvertFromCsv.ToFlight(line);
            if (lineFlight is not null)
            {
                flightList.Add(lineFlight);
            }
        }

        return flightList;
    }

    public async Task UpdateAsync(Flight newFlight)
    {
        var flights = (await GetAllAsync()).ToList();
        var index = flights.FindIndex(b => b.FlightId == newFlight.FlightId);

        if (index != -1)
        {
            flights[index] = newFlight;
            await SaveAllAsync(flights);
        }
    }

    public async Task DeleteAsync(string id)
    {
        var Flights = (await GetAllAsync()).Where(b => b.FlightId != id).ToList();
        await SaveAllAsync(Flights);
    }

    private async Task SaveAllAsync(IEnumerable<Flight> flights)
    {
        var lines = new List<string>(flights.Select(f => $"{ConvertToCsv.FromFlight(f)}{Environment.NewLine}"));
        await File.WriteAllLinesAsync(_filePath, lines);
    }
}

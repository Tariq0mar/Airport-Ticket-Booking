using AirportTicketBooking.Convert;
using AirportTicketBooking.Interfaces.Repositories;
using AirportTicketBooking.Models;
using AirportTicketBooking.Serializers;

namespace AirportTicketBooking.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly string _filePath = Path.GetFullPath(Path.Combine("..", "..", "..", "DataBase", "flights.csv"));
    private static int _idCounter = 0;

    public async Task AddAsync(Booking booking)
    {
        var line = $"{ConvertToCsv.FromBooking(booking)}{Environment.NewLine}";
        var parts = line.Split(',');
        parts[0] = (++_idCounter).ToString("D11");
        line = string.Join(",", parts);

        await File.AppendAllTextAsync(_filePath, line);
    }

    public async Task<Booking?> GetByBookingIdAsync(string id)
    {
        var bookings = await GetAllAsync();
        return bookings.FirstOrDefault(b => b.Id == id);
    }

    public async Task<IEnumerable<Booking>> GetByPassengerIdAsync(string id)
    {
        var bookingsList = await GetAllAsync();
        var passengerBookingsList = new List<Booking>();

        foreach (var booking in bookingsList)
        {
            if (booking.PassengerId == id)
            {
                passengerBookingsList.Add(booking);
            }
        }

        return passengerBookingsList;
    }

    public async Task<IEnumerable<Booking>> GetAllAsync()
    {
        var lines = await File.ReadAllLinesAsync(_filePath);
        var bookingsList = new List<Booking>();

        foreach (var line in lines)
        {
            var booking = ConvertFromCsv.ToBooking(line);
            if(booking is not null) 
            { 
                bookingsList.Add(booking);
            }
        }

        return bookingsList;
    }

    public async Task UpdateAsync(Booking newBooking)
    {
        var bookings = (await GetAllAsync()).ToList();
        var index = bookings.FindIndex(b => b.Id == newBooking.Id);

        if (index != -1)
        {
            bookings[index] = newBooking;
            await SaveAllAsync(bookings);
        }
    }

    public async Task DeleteAsync(string id)
    {
        var bookings = (await GetAllAsync()).Where(b => b.Id != id).ToList();
        await SaveAllAsync(bookings);
    }

    private async Task SaveAllAsync(IEnumerable<Booking> bookings)
    {
        var lines = new List<string>(bookings.Select(b => $"{ConvertToCsv.FromBooking(b)}{Environment.NewLine}"));
        await File.WriteAllLinesAsync(_filePath, lines);
    }
}

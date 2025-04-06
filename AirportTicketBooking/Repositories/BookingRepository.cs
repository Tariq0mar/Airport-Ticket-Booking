using AirportTicketBooking.Convert;
using AirportTicketBooking.Interfaces.Repositories;
using AirportTicketBooking.Models;
using AirportTicketBooking.ModelsFactories;
using AirportTicketBooking.Serializers;

namespace AirportTicketBooking.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly string _filePath = "D:\\Airport-Ticket-Booking\\AirportTicketBooking\\DataBase\\bookings.csv";
    private static int _idCounter = 0;

    public async Task AddBookingAsync(Booking booking)
    {
        booking.Id = (++_idCounter).ToString("D11");
        var line = $"{ConvertToCsv.FromBooking(booking)}{Environment.NewLine}";
        await File.AppendAllTextAsync(_filePath, line);
    }

    public async Task<Booking?> GetBookingByIdAsync(string id)
    {
        var bookings = await GetAllBookingsAsync();
        return bookings.FirstOrDefault(b => b.Id == id);
    }

    public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
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

    public async Task UpdateBookingAsync(Booking newBooking)
    {
        var bookings = (await GetAllBookingsAsync()).ToList();
        var index = bookings.FindIndex(b => b.Id == newBooking.Id);

        if (index != -1)
        {
            bookings[index] = newBooking;
            await SaveAllBookingsAsync(bookings);
        }
    }

    public async Task DeleteBookingAsync(string id)
    {
        var bookings = (await GetAllBookingsAsync()).Where(b => b.Id != id).ToList();
        await SaveAllBookingsAsync(bookings);
    }

    private async Task SaveAllBookingsAsync(IEnumerable<Booking> bookings)
    {
        var lines = new List<string>(bookings.Select(b => $"{ConvertToCsv.FromBooking(b)}{Environment.NewLine}"));
        await File.WriteAllLinesAsync(_filePath, lines);
    }
}

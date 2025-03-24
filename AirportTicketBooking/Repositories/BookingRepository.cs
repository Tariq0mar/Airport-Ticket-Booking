using AirportTicketBooking.Interfaces.Repositories;
using AirportTicketBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBooking.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly string _filePath = "D:\\Airport-Ticket-Booking\\AirportTicketBooking\\DataBase\\bookings.csv";

    public BookingRepository()
    {
    }

    public async Task AddBookingAsync(Booking booking)
    {
        var line = $"{booking.Id},{booking.FlightId},{booking.PassengerId}";
        await File.AppendAllTextAsync(_filePath, line);
    }

    public async Task<Booking> GetBookingByIdAsync(int id)
    {
        var bookings = await GetAllBookingsAsync();
        return bookings.FirstOrDefault(booking => booking.Id == id); 
    }

    public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
    {
        var lines = await File.ReadAllLinesAsync(_filePath);
        var bookingsList = new List<Booking>();

        foreach (var line in lines) 
        {
            var parts = line.Split(',');
            if (int.TryParse(parts[0], out int id) &&
                int.TryParse(parts[1], out int flightId) &&
                int.TryParse(parts[2], out int passengerId))
            {
                bookingsList.Add(new Booking(id, flightId, passengerId));
            }
        }

        return bookingsList;
    }

    public async Task UpdateBookingAsync(Booking newBooking)
    {
        var bookings = (await GetAllBookingsAsync()).ToList();
        var index = bookings.FindIndex(booking => booking.Id == newBooking.Id);

        if (index != -1)
        {
            bookings[index] = newBooking;
            await SaveAllBookingsAsync(bookings);
        }
    }

    public async Task DeleteBookingAsync(int id)
    {
        var bookings = (await GetAllBookingsAsync()).Where(booking => booking.Id != id).ToList();
        await SaveAllBookingsAsync(bookings);
    }

    private async Task SaveAllBookingsAsync(IEnumerable<Booking> bookings)
    {
        var lines = new List<string> (bookings.Select(booking => $"{booking.Id},{booking.FlightId},{booking.PassengerId}"));
        await File.WriteAllLinesAsync(_filePath, lines);
    }
}

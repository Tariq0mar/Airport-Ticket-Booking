using AirportTicketBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBooking.AccessDB;


public class AccessBookings
{
    private readonly string _filePath = "DataBase/bookings.csv";

    public async Task<List<Booking>> ReadBookingsAsync()
    {
        var lines = await File.ReadAllLinesAsync(_filePath);

        return lines.Select(line => ParseBooking(line))
                    .ToList();
    }

    public async Task WriteBookingsAsync(List<Booking> bookings)
    {
        
    }

    private Booking ParseBooking(string line)
    {
        var parts = line.Split(',');

        return new Booking(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
    }
}
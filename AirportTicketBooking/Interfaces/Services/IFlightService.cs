using AirportTicketBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBooking.Interfaces.Services;

public interface IFlightService
{
    Task AddFlightAsync(Flight flight);
    Task<Flight> GetFlightAsync(int id);
    Task UpdateFlightAsync(Flight flight);
    Task RemoveFlightAsync(int id);
    Task<IEnumerable<Flight>> GetAllFlightsAsync();
}

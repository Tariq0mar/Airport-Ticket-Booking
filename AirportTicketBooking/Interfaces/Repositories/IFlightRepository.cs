using AirportTicketBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBooking.Interfaces.Repositories;

public interface IFlightRepository
{
    Task AddFlightAsync(Flight flight);
    Task<Flight> GetFlightByIdAsync(int id);
    Task UpdateFlightAsync(Flight flight);
    Task DeleteFlightAsync(int id);
    Task<IEnumerable<Flight>> GetAllFlightsAsync();
}


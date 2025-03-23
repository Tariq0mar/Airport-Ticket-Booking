using AirportTicketBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBooking.Interfaces.Services;

public interface IUserService
{
    Task AddUserAsync(User user);
    Task<User> GetUserByIdAsync(int id);
    Task UpdateUserAsync(User user);
    Task RemoveUserAsync(int id);
    Task<User> AuthenticateUserAsync(string email, string password);
}


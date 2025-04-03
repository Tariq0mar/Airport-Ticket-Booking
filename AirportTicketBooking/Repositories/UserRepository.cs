using AirportTicketBooking.Interfaces.Repositories;
using AirportTicketBooking.Models;

namespace AirportTicketBooking.Repositories;

class UserRepository : IUserRepository
{
    private readonly string _filePath = "D:\\Airport-Ticket-Booking\\AirportTicketBooking\\DataBase\\users.csv";
    private static int _idCounter = 0;

    public async Task AddUserAsync(User user)
    {
        user.UserId = (++_idCounter).ToString("D11");
        var line = $"{user}{Environment.NewLine}";
        await File.AppendAllTextAsync(_filePath, line + Environment.NewLine);
    }

    public async Task<User?> GetUserByIdAsync(string id)
    {
        var users = await GetAllUsersAsync();
        return users.FirstOrDefault(u => u.UserId == id);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        var lines = await File.ReadAllLinesAsync(_filePath);
        var usersList = new List<User>();

        foreach (var line in lines)
        {
            var parts = line.Split(',');
            if (parts.Length == 5)
            {
                usersList.Add(new Manager(parts[0], parts[1], parts[2], parts[3], parts[4]));
            }
            else
            {
                usersList.Add(new Passenger(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5]));
            }
        }

        return usersList;
    }

    public async Task UpdateUserAsync(User user)
    {
        var users = await GetAllUsersAsync();
        var updatedUsers = users.Select(u => u.UserId == user.UserId ? user : u).ToList();
        await SaveAllUsersAsync(updatedUsers);
    }

    public async Task DeleteUserAsync(string id)
    {
        var users = await GetAllUsersAsync();
        var filteredUsers = users.Where(u => u.UserId != id);
        await SaveAllUsersAsync(filteredUsers);
    }

    private async Task SaveAllUsersAsync(IEnumerable<User> users)
    {
        var lines = users.Select(u => u.ToString());
        await File.WriteAllLinesAsync(_filePath, lines);
    }
}

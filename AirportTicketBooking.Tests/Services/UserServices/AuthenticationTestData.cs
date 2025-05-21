using AirportTicketBooking.Enums;
using AirportTicketBooking.Models;

namespace AirportTicketBooking.Tests.Services.UserService
{
    public class AuthenticationTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var passenger = new Passenger
            {
                UserId = "1",
                Role = UserRole.Passenger,
                Name = "Tariq",
                Email = "tariq@gmail.com",
                Password = "123456",
                PhoneNumber = "123456",
                PassportNumber = "123456"
            };
            var manager = new Manager
            {
                UserId = "1",
                Role = UserRole.Manager,
                Name = "Omar",
                Email = "omar@mail.com",
                Password = "123456",
                PhoneNumber = "123456"
            };

            yield return new object[] { "1", "123456", passenger };
            yield return new object[] { "1", "123456", manager };
            yield return new object[] { "1", "123456", null }; 
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

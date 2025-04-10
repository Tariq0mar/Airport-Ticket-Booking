using AirportTicketBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBooking.Presentations.Actions.FlightActions
{
    class BookingPassengerActions
    {
        public void GetFlight()
        {
            Console.Write("Enter Flight ID: ");
            string flightId = Console.ReadLine();
            var flight = _flightService.GetFlight(flightId);
            Console.WriteLine(flight != null ? flight.ToString() : "Flight not found.");
        }

        public void GetAllFlights()
        {
            var flights = _flightService.GetAllFlights();
            Console.WriteLine("=== Available Flights ===");
            foreach (var flight in flights)
            {
                Console.WriteLine(flight);
            }
        }

        public void BookFlight()
        {
            Console.Write("Enter Flight ID to book: ");
            string flightId = Console.ReadLine();

            // You can enhance this to ask for travel class and additional data if needed
            var booking = _bookingService.BookFlight(_passenger.PassengerId, flightId);

            Console.WriteLine(booking != null
                ? $"Booking successful! Booking ID: {booking.Id}"
                : "Booking failed. Please check flight ID and try again.");
        }
    }
}

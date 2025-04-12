namespace AirportTicketBooking.Presentations.Actions.BookingActions
{
    class BookingPassengerActions
    {
        public void MyBookings()
        {
            var bookings = _bookingService.GetBookingsByPassengerId(_passenger.PassengerId);
            Console.WriteLine("=== My Bookings ===");
            if (!bookings.Any())
            {
                Console.WriteLine("You have no bookings.");
                return;
            }

            foreach (var booking in bookings)
            {
                Console.WriteLine(booking);
            }
        }
    }
}

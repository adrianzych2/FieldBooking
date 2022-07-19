namespace Data.Repository
{
    public class BookingRepository : IBookingRepository
    {

        private readonly FieldBookingContext _context;

        public BookingRepository(FieldBookingContext context)
        {
            _context = context;
        }

        public void AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public Booking GetBooking(int id)
        {
            return _context.Bookings.FirstOrDefault(x => x.Id == id);
        }

        public List<Booking> GetAllBookings()
        {
            return _context.Bookings.ToList();
        }

        public void RemoveBooking(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(x => x.Id == id);
            _context.Bookings.Remove(booking);
        }
    }
}

using AutoMapper;
using FieldBooking.Data.Models;
using FieldBooking.Domain.Models;
using FieldBooking.Domain.Repository;

namespace FieldBooking.Data.Repository
{
    public class BookingRepository : IBookingRepository
    {

        private readonly FieldBookingContext _context;
        private readonly IMapper _mapper;

        public BookingRepository(FieldBookingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddBooking(BookingDto bookingDto)
        {
            var booking = _mapper.Map<Booking>(bookingDto);
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public BookingDto GetBooking(int id)
        {
            return _mapper.Map<BookingDto>(_context.Bookings.FirstOrDefault(x => x.Id == id));
        }

        public List<BookingDto> GetAllBookings()
        {
            return _mapper.Map<List<BookingDto>>(_context.Addresses.ToList());
        }

        public void RemoveBooking(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(x => x.Id == id);
            _context.Bookings.Remove(booking);
        }
    }
}

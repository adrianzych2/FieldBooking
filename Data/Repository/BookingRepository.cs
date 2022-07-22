using AutoMapper;
using FieldBooking.Data.Models;
using FieldBooking.Domain.Models;
using FieldBooking.Domain.Repository;
using Microsoft.EntityFrameworkCore;

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


        public async Task<BookingDto> CreateAsync(BookingDto bookingDto)
        {
            var booking = _mapper.Map<Booking>(bookingDto);
          
            await _context.Bookings.AddAsync(booking);
                
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return _mapper.Map<BookingDto>(booking);
        }

        public async Task<BookingDto> GetAsync(int id)
        {
            return _mapper.Map<BookingDto>(await _context.Bookings.FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<List<BookingDto>> GetAllAsync()

        {

            try
            {
                var allBookings = await _context.Bookings.ToListAsync();
                return _mapper.Map<List<BookingDto>>(allBookings);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new ArgumentException();
            }
        }

        public async Task<BookingDto> RemoveAsync(int id)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(x => x.Id == id);
            if (booking is null) throw new ArgumentException($"Can't find user with specified id: {id}"); 
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return _mapper.Map<BookingDto>(booking);
        }

        public async Task<BookingDto> UpdateAsync(BookingDto bookingDto)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(booking=>booking.Id==bookingDto.Id);
            if (booking is null) throw new ArgumentException($"Can't find booking in database");
            _mapper.Map(bookingDto, booking);
            await _context.SaveChangesAsync();
            return _mapper.Map<BookingDto>(booking);
        }
    }
}

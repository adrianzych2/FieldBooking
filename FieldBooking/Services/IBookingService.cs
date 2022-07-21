using FieldBooking.Domain.Models;

namespace FieldBooking.Services
{
    public interface IBookingService
    {
        Task<BookingDto> CreateAsync(BookingDto bookingDto);
    }
}

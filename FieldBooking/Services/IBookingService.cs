using FieldBooking.Domain.Models;

namespace FieldBooking.Services
{
    public interface IBookingService
    {
        Task<BookingDto> CreateAsync(BookingDto bookingDto);
        Task<bool> CheckAvailabilityAsync(BookingDto bookingDto);
        Task<BookingDto> GetAsync(int id);
        Task<List<BookingDto>> GetAllAsync();
        Task<BookingDto> RemoveAsync(int id);
        Task<BookingDto> UpdateAsync(BookingDto bookingDto);
    }
}

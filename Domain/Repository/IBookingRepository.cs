using FieldBooking.Domain.Models;

namespace FieldBooking.Domain.Repository
{

public interface IBookingRepository
{
    void AddBooking(BookingDto bookingDto);
    BookingDto GetBooking(int id);
    List<BookingDto> GetAllBookings();
    void RemoveBooking(int id);
}

}
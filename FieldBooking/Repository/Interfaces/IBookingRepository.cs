using FieldBooking.Models;

namespace FieldBooking.Repository.Interfaces
{

public interface IBookingRepository
{
    void AddBooking(Booking booking);
    Booking GetBooking(int id);
    List<Booking> GetAllBookings();
    void RemoveBooking(int id);
}

}
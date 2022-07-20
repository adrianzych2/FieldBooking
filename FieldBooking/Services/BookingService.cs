using FieldBooking.Domain.Repository;

namespace FieldBooking.Services
{
    public class BookingService : IBookingService
    {
        private IBookingRepository _repository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _repository = bookingRepository;
        }
        /*public bool CheckAvaibility(Booking booking)
        {
            if (_repository.GetBooking(booking.Id) != null)
            {

            }
        }*/
    }
}

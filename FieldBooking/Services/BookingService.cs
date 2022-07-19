namespace FieldBooking.Services
{
    public class BookingService
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

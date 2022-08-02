namespace FieldBooking.Data.Models
{
    public class BookingBuilder
    {
        private Booking booking;

        public BookingBuilder()
        {
            booking = new Booking();
        }

        public BookingBuilder WithId(int id)
        {
            booking.Id = id;
            return this;
        }

        public BookingBuilder WithUserId(int userId)
        {
            booking.UserId = userId;
            return this;
        }

        public BookingBuilder WithFieldId(int fieldId)
        {
            booking.FieldId = fieldId;
            return this;
        }

        public BookingBuilder WithField(Field field)
        {
            booking.Field = field;
            return this;
        }

        public BookingBuilder WithStartBooking(DateTime startBooking)
        {
            booking.StartBooking = startBooking;
            return this;
        }

        public BookingBuilder WithEndBooking(DateTime endBooking)
        {
            booking.EndBooking = endBooking;
            return this;
        }

        public BookingBuilder WithConfirmed(bool confirmed)
        {
            booking.Confirmed = confirmed;
            return this;
        }
    }
}

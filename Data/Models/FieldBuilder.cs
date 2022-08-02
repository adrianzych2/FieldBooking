using FieldBooking.Domain.Models.Enums;

namespace FieldBooking.Data.Models
{
    public class FieldBuilder
    {
        private Field field;

        public FieldBuilder()
        {
            field = new Field();
        }

        public static FieldBuilder NewField()
        {
            return new FieldBuilder();
        }

        public FieldBuilder WithId(int id)
        {
            field.Id = id;
            return this;
        }

        public FieldBuilder WithName(string name)
        {
            field.Name = name;
            return this;
        }

        public FieldBuilder WithFieldType(FieldType fieldType)
        {
            field.FieldType = fieldType;
            return this;
        }

        public FieldBuilder WithAddressId(int addressId)
        {
            field.AddressId = addressId;
            return this;
        }

        public FieldBuilder WithAddress(Address address)
        {
            field.Address = address;
            return this;
        }

        public FieldBuilder WithPrice(decimal price)
        {
            field.Price = price;
            return this;
        }

        public FieldBuilder WithOneBookingTime(DateTime oneBookingTime)
        {
            field.OneBookingTime = oneBookingTime;
            return this;
        }

        public FieldBuilder WithCalendarId(int calendarId)
        {
            field.CalendarId = calendarId;
            return this;
        }

        public FieldBuilder WithCalendar(Calendar calendar)
        {
            field.Calendar = calendar;
            return this;
        }
    }
}

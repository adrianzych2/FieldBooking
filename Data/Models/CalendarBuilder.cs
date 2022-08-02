namespace FieldBooking.Data.Models
{
    public class CalendarBuilder
    {
        private Calendar calendar;

        public CalendarBuilder()
        {
            calendar = new Calendar();
        }

        public CalendarBuilder WithId(int id)
        {
            calendar.Id = id;
            return this;
        }

        public CalendarBuilder WithAvailableFrom(DateTime availableFrom)
        {
            calendar.AvailableFrom = availableFrom;
            return this;
        }

        public CalendarBuilder WithAvailableTo(DateTime availableTo)
        {
            calendar.AvailableTo = availableTo;
            return this;
        }

        public CalendarBuilder WithAvailabilityHoursStart(DateTime availabilityHoursStart)
        {
            calendar.AvailabilityHoursStart = availabilityHoursStart;
            return this;
        }

        public CalendarBuilder WithAvailabilityHoursEnd(DateTime availabilityHoursEnd)
        {
            calendar.AvailabilityHoursEnd = availabilityHoursEnd;
            return this;
        }

        public CalendarBuilder WithIsOpenInWeekend(bool isOpenInWeekend)
        {
            calendar.IsOpenInWeekend = isOpenInWeekend;
            return this;
        }
    }
}

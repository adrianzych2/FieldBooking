namespace FieldBooking.Domain.Models
{
    public class CalendarDto
    {
        public int Id { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }

        public DateTime AvailabilityHoursStart { get; set; }
        public DateTime AvailabilityHoursEnd { get; set; }

        public bool IsOpenInWeekend { get; set; }

        public List<DateTime> UnavailableDays { get; set; }
    }
}

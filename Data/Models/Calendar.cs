using System.ComponentModel.DataAnnotations;

namespace FieldBooking.Data.Models
{
    public class Calendar
    {
        [Key]
        public int Id { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }

        public DateTime AvailabilityHoursStart { get; set; }
        public DateTime AvailabilityHoursEnd { get; set; }

        public bool IsOpenInWeekend { get; set; }
    }
}

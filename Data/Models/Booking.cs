using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldBooking.Data.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(Field))]
        public int FieldId { get; set; }
        public Field Field { get; set; }
        public DateTime StartBooking { get; set; }
        public DateTime EndBooking { get; set; }
        public bool Confirmed { get; set; }
    }
}

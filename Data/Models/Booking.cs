using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FieldBooking.Data.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        public ApplicationUser User { get; set; }
        public int FieldId { get; set; }
        public Field Field  { get; set; }

        public DateTime StartBooking { get; set; }
        public DateTime EndBooking { get; set; }

        public bool Confirmed { get; set; }

    }
}

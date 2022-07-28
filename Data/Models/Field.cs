using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FieldBooking.Domain.Models.Enums;

namespace FieldBooking.Data.Models
{
    public class Field
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Required]
        public FieldType FieldType { get; set; }

        [ForeignKey(nameof(AddressId))]
        public int AddressId { get; set; }
        [Required]
        public Address Address { get; set; }

        public decimal Price { get; set; }
        [Required]
        public DateTime OneBookingTime { get; set; }

        public int CalendarId { get; set; }

        public Calendar Calendar { get; set; }
    }
}

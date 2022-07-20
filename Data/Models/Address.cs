using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldBooking.Data.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(25)")]
        public string City { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string Region { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string PostalCode { get; set; }
        [Required]
        [Column(TypeName = "varchar(25)")]

        public string Country { get; set; }

        [Required]
        [Column(TypeName = "varchar(25)")]
        public string Street { get; set; }

        public int StreetNumber { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;



namespace Domain.Models

{
    public class BookingDto
    {
        public int Id { get; set; }

        public IdentityUser User { get; set; }
        public int FieldId { get; set; }
        public FieldDto Field { get; set; }

        public DateTime StartBooking { get; set; }
        public DateTime EndBooking { get; set; }

        public bool Confirmed { get; set; }
    }
}

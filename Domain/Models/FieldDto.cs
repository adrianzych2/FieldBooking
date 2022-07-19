using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Enums;

namespace Domain.Models
{
    public class FieldDto
    {
        public int Id { get; set; }


        public string Name { get; set; }


        public FieldType FieldType { get; set; }


        public int AddressId { get; set; }

        public AddressDto Address { get; set; }

        public int Price { get; set; }

        public DateTime OneBookingTime { get; set; }

        public int CalendarId { get; set; }

        public CalendarDto Calendar { get; set; }
    }
}

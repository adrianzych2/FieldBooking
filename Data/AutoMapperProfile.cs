using AutoMapper;
using FieldBooking.Data.Models;
using FieldBooking.Domain.Models;

namespace FieldBooking.Data
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Field, FieldDto>().ReverseMap();
            CreateMap<Booking, BookingDto>().ReverseMap();
            CreateMap<Calendar, CalendarDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}

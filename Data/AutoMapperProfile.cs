using AutoMapper;
using FieldBooking.Data.Models;
using FieldBooking.Domain.Models;
using Microsoft.AspNetCore.Identity;

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
            CreateMap<ApplicationUser, CreateApplicationUserDto>().ReverseMap();
            CreateMap<ApplicationUser, LoginApplicationUserDto>().ReverseMap();
        }
    }
}

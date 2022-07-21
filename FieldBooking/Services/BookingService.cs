using System.Diagnostics;
using FieldBooking.Domain.Models;
using FieldBooking.Domain.Repository;

namespace FieldBooking.Services
{
    public class BookingService : IBookingService
    {
        private IBookingRepository _repository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _repository = bookingRepository;
        }

        public async Task<BookingDto> CreateAsync(BookingDto bookingDto)
        {
            var allBookings = await _repository.GetAllAsync();
            if (allBookings == null)
            {
                await _repository.CreateAsync(bookingDto);
            }
            var sameDayBookings = allBookings.Where(x => x.FieldId == bookingDto.FieldId)
                .Where(x => x.StartBooking.Day == bookingDto.StartBooking.Day).ToList();

            if (sameDayBookings.FirstOrDefault(x=>x.StartBooking <= bookingDto.StartBooking && x.EndBooking >= bookingDto.EndBooking) != null
                && (sameDayBookings.FirstOrDefault(x => x.StartBooking >= bookingDto.StartBooking && x.StartBooking >= bookingDto.StartBooking) != null))
            {
                await _repository.CreateAsync(bookingDto);
            }
            else if (sameDayBookings.Count == 0)
            {
                await _repository.CreateAsync(bookingDto);
            }
            throw new ArgumentException("This field is booked at this time");
        }
    }
}

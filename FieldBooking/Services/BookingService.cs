using FieldBooking.Domain.Models;
using FieldBooking.Domain.Repository;

namespace FieldBooking.Services
{
    
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _repository = bookingRepository;
        }

        public async Task<BookingDto> CreateAsync(BookingDto bookingDto)
        {
            if (await CheckAvailabilityAsync(bookingDto))
            {
                await _repository.CreateAsync(bookingDto);
            }
            throw new ArgumentException("This field is booked at this time");
        }

        public async Task<bool> CheckAvailabilityAsync(BookingDto bookingDto)
        {
            var allBookings = await _repository.GetAllAsync();

            if (allBookings == null)
            {
                return true;
            }

            var sameDayBookings = allBookings.Where(x => x.FieldId == bookingDto.FieldId)
                .Where(x => x.StartBooking.Day == bookingDto.StartBooking.Day).ToList();
            if (sameDayBookings.Count == 0)
            {
                return true;
            }
            if (sameDayBookings.FirstOrDefault(x =>
                    x.StartBooking < bookingDto.StartBooking && x.EndBooking > bookingDto.StartBooking) == null
                && sameDayBookings.FirstOrDefault(x =>
                    x.StartBooking > bookingDto.StartBooking && x.StartBooking < bookingDto.EndBooking) == null
                && sameDayBookings.FirstOrDefault(x => x.StartBooking == bookingDto.StartBooking) == null)
            {
                return true;
            }
            return false;
        }

        public async Task<BookingDto> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<List<BookingDto>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<BookingDto> RemoveAsync(int id)
        {
            return await _repository.RemoveAsync(id);
        }

        public async Task<BookingDto> UpdateAsync(BookingDto bookingDto)
        {
            return await _repository.UpdateAsync(bookingDto);
        }


    }
}

﻿using AutoMapper;
using FieldBooking.Data.Models;
using FieldBooking.Domain.Models;
using FieldBooking.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace FieldBooking.Data.Repository
{
    
    public class BookingRepository : IBookingRepository
    {

        private readonly FieldBookingContext _context;
        private readonly IMapper _mapper;

        public BookingRepository(FieldBookingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<BookingDto> CreateAsync(BookingDto bookingDto)
        {
            var booking = _mapper.Map<Booking>(bookingDto);
            await _context.Bookings.AddAsync(booking);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return _mapper.Map<BookingDto>(booking);
        }

        public async Task<BookingDto> GetAsync(int id)
        {
            return _mapper.Map<BookingDto>(_context.Bookings.Include(x=>x.User).FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<List<BookingDto>> GetAllAsync()

        {
            List<BookingDto> allBookings;
            try
            {
                allBookings = _mapper.Map<List<BookingDto>>(_context.Bookings.ToListAsync());
                return _mapper.Map<List<BookingDto>>(_context.Bookings.ToListAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<BookingDto> RemoveAsync(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(x => x.Id == id);
            if (booking is null) throw new ArgumentException($"Can't find user with specified id: {id}");
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return _mapper.Map<BookingDto>(booking);
        }

        public async Task<BookingDto> UpdateAsync(BookingDto bookingDto)
        {
            var booking = await _context.Bookings.Include(x => x.User).FirstOrDefaultAsync();
            if (booking is null) throw new ArgumentException($"Can't find booking in database");
            _mapper.Map(bookingDto, booking);
            await _context.SaveChangesAsync();
            return _mapper.Map<BookingDto>(booking);
        }
    }
}

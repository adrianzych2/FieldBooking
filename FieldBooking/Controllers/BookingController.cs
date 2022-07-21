using AutoMapper;
using FieldBooking.Domain.Models;
using FieldBooking.Services;
using Microsoft.AspNetCore.Mvc;

namespace FieldBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _mapper = mapper;
            _bookingService = bookingService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Add")]
        public async Task<ActionResult> Create([FromBody] BookingDto bookingDto)
        {
            var booking = _bookingService.CreateAsync(bookingDto);
            return Ok(booking);
        }
    }
}

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
            var booking = await _bookingService.CreateAsync(bookingDto);
            return Ok(booking);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<IList<BookingDto>>> GetAll()
        {
            var fields = await _bookingService.GetAllAsync();
            return Ok(fields);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var car = await _bookingService.GetAsync(id);
            return Ok(car);
        }

        [HttpPut("Remove/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Remove([FromRoute] int id)
        {
            var field = await _bookingService.RemoveAsync(id);
            return Ok(field);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Update")]

        public async Task<ActionResult> Update([FromBody] BookingDto bookingDto)
        {
            var field = await _bookingService.UpdateAsync(bookingDto);
            return Ok(field);
        }
    }
}

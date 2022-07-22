using AutoMapper;
using FieldBooking.Domain.Models;
using FieldBooking.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FieldBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FieldController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFieldService _fieldService;
        public FieldController(IFieldService fieldService, IMapper mapper)
        {
            _mapper = mapper;
            _fieldService = fieldService;
        }

        [HttpPost]
        //do testów 
        [Authorize(Roles ="Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Add")]
        public async Task<ActionResult> Create([FromBody] FieldDto fieldDto)
        {
            var field = await _fieldService.CreateAsync(fieldDto);
            return Ok(field);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        
        public async Task<ActionResult<IList<FieldDto>>> GetAll()
        {
            var fields = await _fieldService.GetAllAsync();
            return Ok(fields);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var car = await _fieldService.GetAsync(id);
            return Ok(car);
        }

        [HttpPut("Remove/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Remove([FromRoute] int id)
        {
            var field = await _fieldService.RemoveAsync(id);
            return Ok(field);
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Update")]

        public async Task<ActionResult> Update([FromBody] FieldDto fieldDto)
        {
            var field = await _fieldService.UpdateAsync(fieldDto);
            return Ok(field);
        }
    }
}

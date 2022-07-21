using AutoMapper;
using FieldBooking.Data.Models;
using FieldBooking.Domain.Models;
using FieldBooking.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace FieldBooking.Data.Repository
{
    public class FieldRepository : IFieldRepository
    {
        private readonly FieldBookingContext _context;
        private readonly IMapper _mapper;

        public FieldRepository(FieldBookingContext fieldBookingContext, IMapper mapper)
        {
            _context = fieldBookingContext;
            _mapper = mapper;

        }

        public async Task<FieldDto> CreateAsync(FieldDto fieldDto)
        {
            var field = _mapper.Map<Field>(fieldDto);
            await _context.Fields.AddAsync(field);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return _mapper.Map<FieldDto>(field);
        }

        public async Task<FieldDto> GetAsync(int id)
        {
            return _mapper.Map<FieldDto>(await _context.Fields.Include(x=>x.Address).Include(x=>x.Calendar).FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<List<FieldDto>> GetAllAsync ()
        {
            return _mapper.Map<List<FieldDto>>(await _context.Fields
                .Include(field=>field.Address)
                .Include(field=>field.Calendar).ToListAsync());
        }

        public async Task<FieldDto> RemoveAsync(int id)
        {
            var field = await _context.Fields.FirstOrDefaultAsync(field => field.Id == id);
            if (field is null) throw new ArgumentException($"Can't find user with specified id: {id}");
            _context.Fields.Remove(field);
            await _context.SaveChangesAsync();
            return _mapper.Map<FieldDto>(field);
        }

        public async Task<FieldDto> UpdateAsync(FieldDto fieldDto)
        {
            var field = await _context.Fields.FirstOrDefaultAsync(field => field.Id == fieldDto.Id);
            if (field is null) throw new ArgumentException($"Can't find field in database");
            _mapper.Map(fieldDto, field);
            await _context.SaveChangesAsync();
            return _mapper.Map<FieldDto>(field);
        }
    }
}

using AutoMapper;
using FieldBooking.Data.Models;
using FieldBooking.Domain.Models;
using FieldBooking.Domain.Repository;

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

        public void AddField(FieldDto fieldDto)
        {
            var field = _mapper.Map<Field>(fieldDto);
            _context.Fields.Add(field);
            _context.SaveChanges();
        }

        public FieldDto GetField(int id)
        {
            return _mapper.Map<FieldDto>(_context.Fields.FirstOrDefault(x => x.Id == id));
        }

        public List<FieldDto> GetAllField()
        {
            return _mapper.Map<List<FieldDto>>(_context.Fields.ToList());
        }

        public void RemoveField(int id)
        {
            var field = _context.Fields.FirstOrDefault(x => x.Id == id);
            _context.Fields.Remove(field);
        }
    }
}

using FieldBooking.Data.Models;
using FieldBooking.Domain.Models;
using FieldBooking.Domain.Repository;

namespace FieldBooking.Data.Repository
{
    public class FieldRepository : IFieldRepository
    {
        private readonly FieldBookingContext _context;

        public FieldRepository(FieldBookingContext fieldBookingContext)
        {
            _context = fieldBookingContext;
        }

        public void AddField(Field field)
        {
            _context.Fields.Add(field);
            _context.SaveChanges();
        }

        public FieldDto GetField(int id)
        {
            return _context.Fields.FirstOrDefault(x => x.Id == id);
        }

        public List<FieldDto> GetAllField()
        {
            return _context.Fields.ToList();
        }

        public void RemoveField(int id)
        {
            var field = _context.Fields.FirstOrDefault(x => x.Id == id);
            _context.Fields.Remove(field);
        }
    }
}

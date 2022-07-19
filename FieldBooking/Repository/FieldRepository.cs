using FieldBooking.Data;
using FieldBooking.Models;
using FieldBooking.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FieldBooking.Repository
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

        public Field GetField(int id)
        {
            return _context.Fields.FirstOrDefault(x => x.Id == id);
        }

        public List<Field> GetAllField()
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

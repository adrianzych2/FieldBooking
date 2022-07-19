using FieldBooking.Models;

namespace FieldBooking.Repository.Interfaces
{

    public interface IFieldRepository
    {
        void AddField(Field field);
        Field GetField(int id);
        List<Field> GetAllField();
        void RemoveField(int id);
    }
}
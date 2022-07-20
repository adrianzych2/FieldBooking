using FieldBooking.Domain.Models;

namespace FieldBooking.Domain.Repository
{

    public interface IFieldRepository
    {
        void AddField(FieldDto fieldDto);
        FieldDto GetField(int id);
        List<FieldDto> GetAllField();
        void RemoveField(int id);
    }
}
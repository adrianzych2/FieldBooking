using FieldBooking.Domain.Models;

namespace FieldBooking.Domain.Repository
{

    public interface IFieldRepository
    {
        Task<FieldDto> CreateAsync(FieldDto fieldDto);
        Task<FieldDto> GetAsync(int id);
        Task<List<FieldDto>> GetAllAsync();
        Task<FieldDto> RemoveAsync(int id);

        Task<FieldDto> UpdateAsync(FieldDto fieldDto);
    }
}
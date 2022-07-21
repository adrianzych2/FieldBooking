using FieldBooking.Domain.Models;

namespace FieldBooking.Services;

public interface IFieldService
{
    public Task<FieldDto> CreateAsync(FieldDto fieldDto);

    public Task<List<FieldDto>> GetAllAsync();

    public Task<FieldDto> GetAsync(int id);

    public Task<FieldDto> RemoveAsync(int id);

    Task<FieldDto> UpdateAsync(FieldDto fieldDto);

}
using FieldBooking.Domain.Models;
using FieldBooking.Domain.Repository;

namespace FieldBooking.Services
{
    public class FieldService : IFieldService
    {
        private readonly IFieldRepository _fieldRepository;

        public FieldService(IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
        }

        public async Task<FieldDto> CreateAsync(FieldDto fieldDto)
        {
            return await _fieldRepository.CreateAsync(fieldDto);
        }

        public async Task<List<FieldDto>> GetAllAsync()
        {
            return await _fieldRepository.GetAllAsync();
        }

        public async Task<FieldDto> GetAsync(int id)
        {
            return await _fieldRepository.GetAsync(id);
        }

     

        public Task<FieldDto> RemoveAsync(int id)
        {
            return _fieldRepository.RemoveAsync(id);
        }

        public Task<FieldDto> UpdateAsync(FieldDto fieldDto)
        {
            return _fieldRepository.UpdateAsync(fieldDto);
        }
    }
}

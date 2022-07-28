using FieldBooking.Data.Models;
using FieldBooking.Domain.Models;
using FieldBooking.Domain.Repository;
using FieldBooking.Services.BusinessValidation;

namespace FieldBooking.Services
{
    public class FieldService : IFieldService
    {
        private readonly IFieldRepository _fieldRepository;
        private readonly IFieldValidationService _fieldValidationService;

        public FieldService(IFieldRepository fieldRepository, IFieldValidationService fieldValidationService)
        {
            _fieldRepository = fieldRepository;
            _fieldValidationService = fieldValidationService;
        }

        public async Task<FieldDto> CreateAsync(FieldDto fieldDto)
        {
            var fields = await GetAllAsync();
            _fieldValidationService.ValidateNewField(fields,fieldDto);
            return await _fieldRepository.CreateAsync(fieldDto);
        }

        public bool CheckIfFieldExistsAsync(List<FieldDto> fields,FieldDto field)
        {
            if (fields.FirstOrDefault(x => x.Name.ToUpper() == field.Name.ToUpper()) != null)
            {
                return false;
            }

            if (fields.FirstOrDefault(x => x.Address.Street.ToUpper() == field.Address.Street.ToUpper()) != null &&
                fields.FirstOrDefault(x => x.Address.StreetNumber == field.Address.StreetNumber)!= null &&
                fields.FirstOrDefault(x => x.Address.City.ToUpper() == field.Address.City.ToUpper()) != null)
            {
                return false;
            }

            return true;
        }

        public async Task<List<FieldDto>> GetAllAsync()
        {
            return await _fieldRepository.GetAllAsync();
        }

        public async Task<FieldDto> GetAsync(int id)
        {
            var field = await _fieldRepository.GetAsync(id);
            if (field is null)
            {
                throw new ArgumentException($"Can't find field with specified id: {id}");
            }
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

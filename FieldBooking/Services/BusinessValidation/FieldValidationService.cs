using FieldBooking.Domain.Models;

namespace FieldBooking.Services.BusinessValidation
{
    public class FieldValidationService : IFieldValidationService
    {
        public async Task ValidateNewField(List<FieldDto> fields, FieldDto field)
        {
            if (!CheckIfAddressIsCorrect(fields, field))
            {
                throw new ArgumentException("This name already exists!");
            };
            if (!CheckIfNameIsCorrect(fields, field))
            {
                throw new ArgumentException("This field is our database");
            };

        }

        private bool CheckIfNameIsCorrect(List<FieldDto> fields, FieldDto field)
        {
            if (fields.FirstOrDefault(x => x.Name.ToUpper() == field.Name.ToUpper()) != null)
            {
                return false;
            }

            return true;
        }

        private bool CheckIfAddressIsCorrect(List<FieldDto> fields, FieldDto field)
        {
            if (fields.FirstOrDefault(x => x.Address.Street.ToUpper() == field.Address.Street.ToUpper()) != null &&
                fields.FirstOrDefault(x => x.Address.StreetNumber == field.Address.StreetNumber) != null &&
                fields.FirstOrDefault(x => x.Address.City.ToUpper() == field.Address.City.ToUpper()) != null)
            {
                return false;
            }

            return true;
        }
    }
}

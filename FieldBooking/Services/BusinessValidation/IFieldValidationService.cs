using FieldBooking.Domain.Models;

namespace FieldBooking.Services.BusinessValidation;

public interface IFieldValidationService
{
    Task ValidateNewField(List<FieldDto> fields, FieldDto field);
  
}
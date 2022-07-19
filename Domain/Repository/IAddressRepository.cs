using Domain.Models;

namespace Domain.Repository
{
    public interface IAddressRepository
    {
        void AddAddress(AddressDto addressDto);
        AddressDto GetAddress(int id);
        List<AddressDto> GetAllAddresses();
        void RemoveAddress(int id);
    }
}

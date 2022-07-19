using FieldBooking.Models;

namespace FieldBooking.Repository.Interfaces
{
    public interface IAddressRepository
    {
        void AddAddress(Address address);
        Address GetAddress(int id);
        List<Address> GetAllAddresses();
        void RemoveAddress(int id);
    }
}

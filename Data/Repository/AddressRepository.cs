using FieldBooking.Data.Models;
using FieldBooking.Domain.Models;
using FieldBooking.Domain.Repository;

namespace FieldBooking.Data.Repository
{

    public class AddressRepository : IAddressRepository
    {
        private readonly FieldBookingContext _context;
        public AddressRepository(FieldBookingContext context)
        {
            _context = context;
        }

        public void AddAddress(Address address)
        {
            _context.Addresses.Add(address);
        }

        public AddressDto GetAddress(int id)
        {
            return _context.Addresses.FirstOrDefault(x => x.Id == id);
        }

        public List<AddressDto> GetAllAddresses()
        {
            return _context.Addresses.ToList();
        }

        public void RemoveAddress(int id)
        {
            var address = _context.Addresses.FirstOrDefault(x => x.Id == id);

        }
    }
}

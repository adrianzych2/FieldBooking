using AutoMapper;
using FieldBooking.Data.Models;
using FieldBooking.Domain.Models;
using FieldBooking.Domain.Repository;
namespace FieldBooking.Data.Repository
{

    public class AddressRepository : IAddressRepository
    {
        private readonly FieldBookingContext _context;
        private readonly IMapper _mapper;
        public AddressRepository(IMapper mapper, FieldBookingContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddAddress(AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            _context.Addresses.Add(address);
        }

        public Address GetAddress(int id)
        {
            return _mapper.Map<AddressDto>(_context.Addresses.FirstOrDefault(x => x.Id == id));
        }

        public List<Address> GetAllAddresses()
        {
            return _mapper.Map<List<AddressDto>>( _context.Addresses.ToList());
        }

        public void RemoveAddress(int id)
        {
            var address = _context.Addresses.FirstOrDefault(x => x.Id == id);

        }
    }
}

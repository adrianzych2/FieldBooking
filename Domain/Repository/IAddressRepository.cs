﻿using FieldBooking.Domain.Models;

namespace FieldBooking.Domain.Repository
{
    public interface IAddressRepository
    {
        void AddAddress(AddressDto addressDto);
        AddressDto GetAddress(int id);
        List<AddressDto> GetAllAddresses();
        void RemoveAddress(int id);
    }
}

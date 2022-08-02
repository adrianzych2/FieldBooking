namespace FieldBooking.Data.Models
{
    public class AddressBuilder
    {
        private Address address;

        public AddressBuilder()
        {
            address = new Address();
        }

        public AddressBuilder WithId(int id)
        {
            address.Id = id;
            return this;
        }

        public AddressBuilder WithCity(string city)
        {
            address.City = city;
            return this;
        }

        public AddressBuilder WithRegion(string region)
        {
            address.Region = region;
            return this;
        }

        public AddressBuilder WithPostalCode(string postalCode)
        {
            address.PostalCode = postalCode;
            return this;
        }

        public AddressBuilder WithCountry(string country)
        {
            address.Country = country;
            return this;
        }

        public AddressBuilder WithStreet(string street)
        {
            address.Street = street;
            return this;
        }

        public AddressBuilder WithStreetNumber(int streetNumber)
        {
            address.StreetNumber = streetNumber;
            return this;
        }
    }
}

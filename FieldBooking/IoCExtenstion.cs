using FieldBooking.Data.Repository;
using FieldBooking.Domain.Repository;
using FieldBooking.Services;
using FieldBooking.Services.BusinessValidation;

namespace FieldBooking
{
    public static class IoCExtenstion
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IFieldService, FieldService>();
            services.AddScoped<IFieldValidationService, FieldValidationService>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IFieldRepository, FieldRepository>();
        }

        public static void RegisterValidators(this IServiceCollection services)
        {
            
        }
    }
}

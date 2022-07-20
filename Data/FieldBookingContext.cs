﻿using FieldBooking.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FieldBooking.Data
{
    public class FieldBookingContext : IdentityDbContext<ApplicationUser>
    {
        protected readonly IConfiguration Configuration;

        public FieldBookingContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Field> Fields { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}

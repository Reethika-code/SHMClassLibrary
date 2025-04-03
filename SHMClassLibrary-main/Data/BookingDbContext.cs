using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SHMClassLibrary
{
    public class BookingDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= localhost;Initial Catalog=BookingDetails2; Integrated Security =true; TrustServerCertificate=true");
        }

        public DbSet<Booking> Bookings { get; set; }

    }
}
////////////////////////////////////////////////////////////////////////////////////////////////
//using HotlelManagementClass;
//using Microsoft.EntityFrameworkCore;

//namespace HotelManagementClass
//{
//    public class BookingPaymentContext : DbContext
//    {
//        public DbSet<Hotel> Hotels { get; set; }
//        public DbSet<Room> Rooms { get; set; }
//        public DbSet<Booking> Bookings { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseSqlServer("Data Source= localhost;Initial Catalog=BookingDetails2; Integrated Security =true; TrustServerCertificate=true");
//        }
//    }
//}




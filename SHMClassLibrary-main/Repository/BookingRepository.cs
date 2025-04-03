
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHMClassLibrary
{
    public class BookingRepository
    {
        public void AddBooking(Booking booking)
        {
            using (var context = new BookingDbContext())
            {
                context.Bookings.Add(booking);
                context.SaveChanges();
            }
        }

        public List<Booking> GetAllUsers()
        {
            using (var context = new BookingDbContext())
            {
                var bookings = context.Bookings.ToList();
                return bookings;
            }
        }

        public List<Booking> GetBookingsByBookingID(int BookingID)
        {
            using (var context = new BookingDbContext())
            {
                var bookings = context.Bookings.Where(a => a.BookingID == BookingID).ToList();
                return bookings;
            }
        }

        public void UpdateBooking(int BookingID, DateTime CheckInDate)
        {
            using (var context = new BookingDbContext())
            {
                var existingBooking = context.Bookings.Find(BookingID); // Corrected: Find expects the primary key (BookingID)
                if (existingBooking != null)
                {
                    existingBooking.CheckInDate = CheckInDate; // Updated CheckInDate
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Booking not found.");
                }
            }
        }

        public void DeleteBooking(int BookingID)
        {
            using (var dbContext = new BookingDbContext())
            {
                var bookingToDelete = dbContext.Bookings.Find(BookingID); // Find expects the primary key
                if (bookingToDelete != null)
                {
                    dbContext.Bookings.Remove(bookingToDelete);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Booking not found.");
                }
            }
        }
    }
}
///////////////////////////////////////////////////////////////////////////////
//using HotlelManagementClass;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace HotelManagementClass
//{
//    public class BookingAndPaymentRepository
//    {
//        public void AddBooking(Booking booking)
//        {
//            using (var context = new BookingPaymentContext())
//            {
//                context.Bookings.Add(booking);
//                context.SaveChanges();
//            }
//        }

//        public List<Hotel> GetHotelsByCity(string city)
//        {
//            using (var context = new BookingPaymentContext())
//            {
//                return context.Hotels.Where(h => h.City == city).ToList();
//            }
//        }

//        public List<Room> GetAvailableRooms(DateTime checkIn, DateTime checkOut)
//        {
//            using (var context = new BookingPaymentContext())
//            {
//                return context.Rooms.Where(r =>
//                    !context.Bookings.Any(b =>
//                        b.RoomID == r.RoomID &&
//                        ((checkIn >= b.CheckInDate && checkIn < b.CheckOutDate) ||
//                        (checkOut > b.CheckInDate && checkOut <= b.CheckOutDate))
//                    )).ToList();
//            }
//        }
//    }
//}





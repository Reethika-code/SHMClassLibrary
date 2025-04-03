using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHMClassLibrary
{
    public class Booking
    {
        public int BookingID { get; set; }          // Primary key
        public int UserID { get; set; }            // Foreign key referencing Users
        public int RoomID { get; set; }            // Foreign key referencing Rooms
        public DateTime CheckInDate { get; set; }  // Date and time of check-in
        public DateTime CheckOutDate { get; set; } // Date and time of check-out
                                                   //public string Status { get; set; }          // Status of the booking (e.g., Confirmed, Pending)
        public string Status { get; set; } = "Active";  // Nullable property

        public int PaymentID { get; set; }

    }
}
////////////////////////////////////////////////////////
//using System;
//using System.Collections.Generic;

//namespace HotlelManagementClass
//{
//    public class Hotel
//    {
//        public int HotelID { get; set; }
//        public string Name { get; set; }
//        public string City { get; set; }
//        public int Rating { get; set; }
//        public List<Room> Rooms { get; set; }
//    }

//    public class Room
//    {
//        public int RoomID { get; set; }
//        public int HotelID { get; set; }
//        public string RoomType { get; set; }
//        public decimal Price { get; set; }
//        public bool AvailabilityStatus { get; set; }
//    }

//    public class Booking
//    {
//        public int BookingID { get; set; }
//        public int RoomID { get; set; }
//        public DateTime CheckInDate { get; set; }
//        public DateTime CheckOutDate { get; set; }
//        public int CustomerID { get; set; }
//    }
//}

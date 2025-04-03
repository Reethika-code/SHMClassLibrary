using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHMClassLibrary
{
    
        public class Room_New
        {
            public int RoomID { get; set; }
            public int HotelID { get; set; }
            public string Type { get; set; }
            public float Price { get; set; }
            public string Availability { get; set; }
            public string Features { get; set; }
            public bool IsActive { get; set; }
        }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoHotel.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int GuestID { get; set; }
        public int RoomID { get; set; }

        public virtual Guest Guest { get; set; }
        public virtual Room Room { get; set; }
    }
}
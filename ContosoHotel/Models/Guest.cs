﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoHotel.Models
{
    public class Guest
    {
        public int GuestID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? Identifier { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
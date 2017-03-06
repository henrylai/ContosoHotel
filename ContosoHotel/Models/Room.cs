using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContosoHotel.Models
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomID { get; set; }
        public string RoomType { get; set; }
        public bool Vacancy { get; set; }
        public double Price { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
using ContosoHotel.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ContosoHotel.DAL
{
    public class HotelContext : DbContext
    {
        public HotelContext() : base("HotelContext")
        {
        }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<ContosoHotel.Models.Reservation> Reservations { get; set; }
    }
}
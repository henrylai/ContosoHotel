using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ContosoHotel.Models;

namespace ContosoHotel.DAL
{
    public class HotelInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<HotelContext>
    {
        protected override void Seed(HotelContext context)
        {
            var guests = new List<Guest>
            {
            new Guest{GuestID=1,Name="Carson",Email="abc@abc.com",Address="123 Lollipop Lane, Seattle, WA 98108"},
            new Guest{GuestID=2,Name="Meredith",Email="abc@abc.com",Address="123 Lollipop Lane, Seattle, WA 98108"},
            new Guest{GuestID=3,Name="Arturo",Email="abc@abc.com",Address="123 Lollipop Lane, Seattle, WA 98108"},
            new Guest{GuestID=4,Name="Gytis",Email="abc@abc.com",Address="123 Lollipop Lane, Seattle, WA 98108"},
            };

            guests.ForEach(s => context.Guests.Add(s));
            context.SaveChanges();
            var rooms = new List<Room>
            {
            new Room{RoomID=1050,Vacancy=true},
            new Room{RoomID=4022,Vacancy=true},
            new Room{RoomID=4041,Vacancy=true},
            new Room{RoomID=1045,Vacancy=true},
            new Room{RoomID=3141,Vacancy=true},
            new Room{RoomID=2021,Vacancy=true},
            new Room{RoomID=2042,Vacancy=true}
            };
            rooms.ForEach(s => context.Rooms.Add(s));
            context.SaveChanges();
            /*var enrollments = new List<Enrollment>
            {
            new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            new Enrollment{StudentID=3,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=1050,},
            new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            new Enrollment{StudentID=6,CourseID=1045},
            new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));*/
            context.SaveChanges();
        }
    }
}
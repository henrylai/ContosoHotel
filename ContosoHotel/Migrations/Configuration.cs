namespace ContosoHotel.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContosoHotel.DAL.HotelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContosoHotel.DAL.HotelContext context)
        {
            var guests = new List<Guest>
            {
            new Guest{Name="Carson",Email="abc@abc.com",Address="123 Lollipop Lane, Seattle, WA 98108"},
            new Guest{Name="Meredith",Email="abc@abc.com",Address="123 Lollipop Lane, Seattle, WA 98108"},
            new Guest{Name="Arturo",Email="abc@abc.com",Address="123 Lollipop Lane, Seattle, WA 98108"},
            new Guest{Name="Gytis",Email="abc@abc.com",Address="123 Lollipop Lane, Seattle, WA 98108"},
            };

            guests.ForEach(s => context.Guests.Add(s));
            context.SaveChanges();
            var rooms = new List<Room>
            {
            new Room{RoomID=105,Vacancy=true,RoomType="King", Price=159.99},
            new Room{RoomID=110,Vacancy=true,RoomType="Queen", Price=134.99},
            new Room{RoomID=115,Vacancy=true,RoomType="Queen", Price=134.99},
            new Room{RoomID=205,Vacancy=true,RoomType="King", Price=159.99},
            new Room{RoomID=210,Vacancy=true,RoomType="Twin", Price=119.99},
            new Room{RoomID=215,Vacancy=true,RoomType="Twin", Price=119.99},
            new Room{RoomID=310,Vacancy=true,RoomType="Single", Price=99.99}
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

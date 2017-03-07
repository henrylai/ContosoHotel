using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContosoHotel.DAL;
using ContosoHotel.Models;
using System.Diagnostics;

namespace ContosoHotel.Controllers
{
    public class RoomController : Controller
    {
        private HotelContext db = new HotelContext();

        // GET: Book
        public ActionResult Book()
        {
            return View(db.Rooms.ToList());
        }

        // GET: Room/Reserve/5
        public ActionResult Reserve(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Room/Reserve/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reserve([Bind(Include = "RoomID,RoomType,Vacancy,Price")] Room room, string firstName, string lastName, string email, string address, string phone)
        {
            Debug.WriteLine(firstName + lastName + email + address + phone);
            
            if (ModelState.IsValid)
            {
                
                db.Entry(room).State = EntityState.Modified;
                //room.Vacancy = false;
                db.SaveChanges();
                return RedirectToAction("Confirm", new { roomID = room.RoomID, roomType = room.RoomType, roomPrice = room.Price,
                    guestEmail = email, guestPhone = phone, guestName = firstName + " " + lastName, guestAddress = address });
            }
            return View(room);
        }


        // GET: Confirm
        public ActionResult Confirm(string roomID, string roomType, string roomPrice, string guestEmail, 
                                    string guestPhone, string guestName, string guestAddress)
        {
            ViewData["roomID"] = roomID;
            ViewData["roomType"] = roomType;
            ViewData["roomPrice"] = roomPrice;
            ViewData["guestEmail"] = guestEmail;
            ViewData["guestPhone"] = guestPhone;
            ViewData["guestName"] = guestName;
            ViewData["guestAddress"] = guestAddress;
            return View();
        }


        // GET: Room
        public ActionResult Index()
        {
            return View(db.Rooms.ToList());
        }

        // GET: Room/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoomID,RoomType,Vacancy,Price")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(room);
        }

        // GET: Room/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Room/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoomID,RoomType,Vacancy,Price")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(room);
        }

        // GET: Room/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

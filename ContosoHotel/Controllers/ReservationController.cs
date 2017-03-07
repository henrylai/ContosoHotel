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
using Microsoft.AspNet.Identity;

namespace ContosoHotel.Controllers
{
    public class ReservationController : Controller
    {
        private HotelContext db = new HotelContext();

        // GET: Reservation
        [Authorize]
        public ActionResult MyReservations()
        {
            var userId = User.Identity.GetUserId();
            var userHash = userId.GetHashCode();
            var reservations = from record in db.Reservations
                               where record.Guest.Identifier == userHash
                               select record;
            return View(reservations.ToList());
        }

        // GET: Reservation
        [Authorize]
        public ActionResult Index()
        {
            var reservations = db.Reservations.Include(r => r.Guest).Include(r => r.Room);
            return View(reservations.ToList());
        }

        // GET: Reservation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservation/Create
        public ActionResult Create()
        {
            ViewBag.GuestID = new SelectList(db.Guests, "GuestID", "Name");
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomType");
            return View();
        }

        // POST: Reservation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservationID,GuestID,RoomID")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GuestID = new SelectList(db.Guests, "GuestID", "Name", reservation.GuestID);
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomType", reservation.RoomID);
            return View(reservation);
        }

        // GET: Reservation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.GuestID = new SelectList(db.Guests, "GuestID", "Name", reservation.GuestID);
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomType", reservation.RoomID);
            return View(reservation);
        }

        // POST: Reservation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservationID,GuestID,RoomID")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GuestID = new SelectList(db.Guests, "GuestID", "Name", reservation.GuestID);
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomType", reservation.RoomID);
            return View(reservation);
        }

        // GET: Reservation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
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

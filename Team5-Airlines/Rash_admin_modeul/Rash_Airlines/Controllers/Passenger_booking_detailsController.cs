using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rash_Airlines.Models;

namespace Rash_Airlines.Controllers
{
    public class Passenger_booking_detailsController : Controller
    {
        private Rash_AirlinesEntities db = new Rash_AirlinesEntities();

        // GET: Passenger_booking_details
        public ActionResult Index()
        {
            var passenger_booking_details = db.Passenger_booking_details.Include(p => p.Flights_Master).Include(p => p.Place).Include(p => p.Place1).Include(p => p.Passenger_Reg);
            return View(passenger_booking_details.ToList());
        }

        // GET: Passenger_booking_details/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger_booking_details passenger_booking_details = db.Passenger_booking_details.Find(id);
            if (passenger_booking_details == null)
            {
                return HttpNotFound();
            }
            return View(passenger_booking_details);
        }

        // GET: Passenger_booking_details/Create
        public ActionResult Create()
        {
            ViewBag.flight_id = new SelectList(db.Flights_Master, "flight_id", "flight_name");
            ViewBag.arrival = new SelectList(db.Places, "place_id", "place_name");
            ViewBag.departure = new SelectList(db.Places, "place_id", "place_name");
            ViewBag.passenger_id = new SelectList(db.Passenger_Reg, "passenger_id", "title");
            return View();
        }

        // POST: Passenger_booking_details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "booking_id,no_of_seats,class,departure,arrival,flight_id,passenger_id,booking_Date,journey_date")] Passenger_booking_details passenger_booking_details)
        {
            if (ModelState.IsValid)
            {
                db.Passenger_booking_details.Add(passenger_booking_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.flight_id = new SelectList(db.Flights_Master, "flight_id", "flight_name", passenger_booking_details.flight_id);
            ViewBag.arrival = new SelectList(db.Places, "place_id", "place_name", passenger_booking_details.arrival);
            ViewBag.departure = new SelectList(db.Places, "place_id", "place_name", passenger_booking_details.departure);
            ViewBag.passenger_id = new SelectList(db.Passenger_Reg, "passenger_id", "title", passenger_booking_details.passenger_id);
            return View(passenger_booking_details);
        }

        // GET: Passenger_booking_details/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger_booking_details passenger_booking_details = db.Passenger_booking_details.Find(id);
            if (passenger_booking_details == null)
            {
                return HttpNotFound();
            }
            ViewBag.flight_id = new SelectList(db.Flights_Master, "flight_id", "flight_name", passenger_booking_details.flight_id);
            ViewBag.arrival = new SelectList(db.Places, "place_id", "place_name", passenger_booking_details.arrival);
            ViewBag.departure = new SelectList(db.Places, "place_id", "place_name", passenger_booking_details.departure);
            ViewBag.passenger_id = new SelectList(db.Passenger_Reg, "passenger_id", "title", passenger_booking_details.passenger_id);
            return View(passenger_booking_details);
        }

        // POST: Passenger_booking_details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "booking_id,no_of_seats,class,departure,arrival,flight_id,passenger_id,booking_Date,journey_date")] Passenger_booking_details passenger_booking_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(passenger_booking_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.flight_id = new SelectList(db.Flights_Master, "flight_id", "flight_name", passenger_booking_details.flight_id);
            ViewBag.arrival = new SelectList(db.Places, "place_id", "place_name", passenger_booking_details.arrival);
            ViewBag.departure = new SelectList(db.Places, "place_id", "place_name", passenger_booking_details.departure);
            ViewBag.passenger_id = new SelectList(db.Passenger_Reg, "passenger_id", "title", passenger_booking_details.passenger_id);
            return View(passenger_booking_details);
        }

        // GET: Passenger_booking_details/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger_booking_details passenger_booking_details = db.Passenger_booking_details.Find(id);
            if (passenger_booking_details == null)
            {
                return HttpNotFound();
            }
            return View(passenger_booking_details);
        }

        // POST: Passenger_booking_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Passenger_booking_details passenger_booking_details = db.Passenger_booking_details.Find(id);
            db.Passenger_booking_details.Remove(passenger_booking_details);
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

        public ActionResult DetailSearch()
        {
            ViewBag.dep = new SelectList(db.Places, "place_id", "place_name");
            ViewBag.arr = new SelectList(db.Places, "place_id", "place_name");
            return View();
        }
    }
}

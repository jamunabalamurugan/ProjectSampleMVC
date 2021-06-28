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
    public class Passengers_DetailsController : Controller
    {
        private Rash_AirlinesEntities db = new Rash_AirlinesEntities();

        // GET: Passengers_Details
        public ActionResult Index()
        {
            //TempData["no_of_seats"] = (from c in db.pass)
            var passengers_Details = db.Passengers_Details.Include(p => p.Passenger_booking_details).Include(p => p.Passenger_Reg);
            return View(passengers_Details.ToList());
        }

        // GET: Passengers_Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passengers_Details passengers_Details = db.Passengers_Details.Find(id);
            if (passengers_Details == null)
            {
                return HttpNotFound();
            }
            return View(passengers_Details);
        }

        // GET: Passengers_Details/Create
        public ActionResult Create()
        {
            ViewBag.booking_id = new SelectList(db.Passenger_booking_details, "booking_id", "class");
            ViewBag.passenger_id = new SelectList(db.Passenger_Reg, "passenger_id", "title");
            return View();
        }

        // POST: Passengers_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "first_name,last_name,age,seat_no,passenger_id,booking_id,perhead_cost,status")] Passengers_Details passengers_Details)
        {
            if (ModelState.IsValid)
            {
                db.Passengers_Details.Add(passengers_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.booking_id = new SelectList(db.Passenger_booking_details, "booking_id", "class", passengers_Details.booking_id);
            ViewBag.passenger_id = new SelectList(db.Passenger_Reg, "passenger_id", "title", passengers_Details.passenger_id);
            return View(passengers_Details);
        }

        // GET: Passengers_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passengers_Details passengers_Details = db.Passengers_Details.Find(id);
            if (passengers_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.booking_id = new SelectList(db.Passenger_booking_details, "booking_id", "class", passengers_Details.booking_id);
            ViewBag.passenger_id = new SelectList(db.Passenger_Reg, "passenger_id", "title", passengers_Details.passenger_id);
            return View(passengers_Details);
        }

        // POST: Passengers_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "first_name,last_name,age,seat_no,passenger_id,booking_id,perhead_cost,status")] Passengers_Details passengers_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(passengers_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.booking_id = new SelectList(db.Passenger_booking_details, "booking_id", "class", passengers_Details.booking_id);
            ViewBag.passenger_id = new SelectList(db.Passenger_Reg, "passenger_id", "title", passengers_Details.passenger_id);
            return View(passengers_Details);
        }

        // GET: Passengers_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passengers_Details passengers_Details = db.Passengers_Details.Find(id);
            if (passengers_Details == null)
            {
                return HttpNotFound();
            }
            return View(passengers_Details);
        }

        // POST: Passengers_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Passengers_Details passengers_Details = db.Passengers_Details.Find(id);
            db.Passengers_Details.Remove(passengers_Details);
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

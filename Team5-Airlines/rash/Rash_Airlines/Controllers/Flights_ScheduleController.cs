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
    public class Flights_ScheduleController : Controller
    {
        private Rash_AirlinesEntities db = new Rash_AirlinesEntities();

        // GET: Flights_Schedule
        public ActionResult Index_Schedule()
        {
            var flights_Schedule = db.Flights_Schedule.Include(f => f.Flights_Master).Include(f => f.Routes_Master);
            return View(flights_Schedule.ToList());
        }

        // GET: Flights_Schedule/Details/5
        public ActionResult Details_Schedule(DateTime? journey_date, int? flight_id)
        {
            if (flight_id == null || journey_date == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flights_Schedule flights_Schedule = (from f in db.Flights_Schedule
                                                 where f.journey_date == journey_date && f.flight_id == flight_id
                                                 select f).SingleOrDefault(); 
            if (flights_Schedule == null)
            {
                return HttpNotFound();
            }
            return View(flights_Schedule);
        }

        // GET: Flights_Schedule/Create
        public ActionResult Create_Schedule()
        {
            ViewBag.flight_id = new SelectList(db.Flights_Master, "flight_id", "flight_name");
            ViewBag.route_id = new SelectList(db.Routes_Master, "route_id", "route_id");
            return View();
        }

        // POST: Flights_Schedule/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Schedule([Bind(Include = "route_id,departure_time,arrival_time,duration,flight_id,journey_date,bc_availability,ec_availability")] Flights_Schedule flights_Schedule)
        {
            if (ModelState.IsValid)
            {
                flights_Schedule.bc_availability = 50;
                db.Flights_Schedule.Add(flights_Schedule);
                db.SaveChanges();
                return RedirectToAction("Index_Schedule");
            }

            ViewBag.flight_id = new SelectList(db.Flights_Master, "flight_id", "flight_name", flights_Schedule.flight_id);
            ViewBag.route_id = new SelectList(db.Routes_Master, "route_id", "route_id", flights_Schedule.route_id);
            return View(flights_Schedule);
        }

        // GET: Flights_Schedule/Edit/5
        public ActionResult Edit_Schedule(DateTime? journey_date,int? flight_id)
        {
            if (flight_id == null || journey_date == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flights_Schedule flights_Schedule =(from f in  db.Flights_Schedule
                                               where f.journey_date == journey_date && f.flight_id == flight_id
                                               select f).SingleOrDefault();
            if (flights_Schedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.flight_id = new SelectList(db.Flights_Master, "flight_id", "flight_name", flights_Schedule.flight_id);
            ViewBag.route_id = new SelectList(db.Routes_Master, "route_id", "route_id", flights_Schedule.route_id);
            return View(flights_Schedule);
        }

        // POST: Flights_Schedule/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Schedule([Bind(Include = "route_id,departure_time,arrival_time,duration,flight_id,journey_date,bc_availability,ec_availability")] Flights_Schedule flights_Schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flights_Schedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.flight_id = new SelectList(db.Flights_Master, "flight_id", "flight_name", flights_Schedule.flight_id);
            ViewBag.route_id = new SelectList(db.Routes_Master, "route_id", "route_id", flights_Schedule.route_id);
            return View(flights_Schedule);
        }

        // GET: Flights_Schedule/Delete/5
        public ActionResult Delete_Schedule(DateTime? journey_date, int? flight_id)
        {
            if (flight_id == null || journey_date == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flights_Schedule flights_Schedule = (from f in db.Flights_Schedule
                                                 where f.journey_date == journey_date && f.flight_id == flight_id
                                                 select f).SingleOrDefault();
            if (flights_Schedule == null)
            {
                return HttpNotFound();
            }
            return View(flights_Schedule);
        }

        // POST: Flights_Schedule/Delete/5
        [HttpPost, ActionName("Delete_Schedule")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime? journey_date, int? flight_id)
        {
            Flights_Schedule flights_Schedule = (from f in db.Flights_Schedule
                                                 where f.journey_date == journey_date && f.flight_id == flight_id
                                                 select f).SingleOrDefault();
            db.Flights_Schedule.Remove(flights_Schedule);
            db.SaveChanges();
            return RedirectToAction("Index_Schedule");
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

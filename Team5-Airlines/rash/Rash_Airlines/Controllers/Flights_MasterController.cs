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
    public class Flights_MasterController : Controller
    {
        private Rash_AirlinesEntities db = new Rash_AirlinesEntities();

        // GET: Flights_Master
        public ActionResult Index_Flight()
        {
            var flights_Master = db.Flights_Master.Include(f => f.Routes_Master);
            return View(flights_Master.ToList());
        }

        // GET: Flights_Master/Details/5
        public ActionResult Details_Flight(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flights_Master flights_Master = db.Flights_Master.Find(id);
            if (flights_Master == null)
            {
                return HttpNotFound();
            }
            return View(flights_Master);
        }

        // GET: Flights_Master/Create
        public ActionResult Create_Flight()
        {
            ViewBag.route_id = new SelectList(db.Routes_Master, "route_id", "route_id");
            return View();
        }

        // POST: Flights_Master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Flight([Bind(Include = "flight_id,flight_name,business_capacity,economy_capacity,route_id,flight_status")] Flights_Master flights_Master)
        {
            if (ModelState.IsValid)
            {
                db.Flights_Master.Add(flights_Master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.route_id = new SelectList(db.Routes_Master, "route_id", "route_id", flights_Master.route_id);
            return View(flights_Master);
        }

        // GET: Flights_Master/Edit/5
        public ActionResult Edit_Flight(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flights_Master flights_Master = db.Flights_Master.Find(id);
            if (flights_Master == null)
            {
                return HttpNotFound();
            }
            ViewBag.route_id = new SelectList(db.Routes_Master, "route_id", "route_id", flights_Master.route_id);
            return View(flights_Master);
        }

        // POST: Flights_Master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Flight([Bind(Include = "flight_id,flight_name,business_capacity,economy_capacity,route_id,flight_status")] Flights_Master flights_Master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flights_Master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.route_id = new SelectList(db.Routes_Master, "route_id", "route_id", flights_Master.route_id);
            return View(flights_Master);
        }

        // GET: Flights_Master/Delete/5
        public ActionResult Delete_Flight(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flights_Master flights_Master = db.Flights_Master.Find(id);
            if (flights_Master == null)
            {
                return HttpNotFound();
            }
            return View(flights_Master);
        }

        // POST: Flights_Master/Delete/5
        [HttpPost, ActionName("Delete_Flight")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flights_Master flights_Master = db.Flights_Master.Find(id);
            db.Flights_Master.Remove(flights_Master);
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

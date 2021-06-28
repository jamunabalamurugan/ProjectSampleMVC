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
            ViewBag.booking_id = new SelectList(db.Passenger_booking_details, "booking_id", "booking_id");
            ViewBag.passenger_id = new SelectList(db.Passenger_Reg, "passenger_id", "passenger_id");
            var flight_id = TempData["flight_id"]; 
            ViewBag.seatno_result = (from c in db.Passengers_Details
                                     join pd in db.Passenger_booking_details
                                     on c.booking_id equals pd.booking_id
                                     where pd.flight_id == (int)flight_id
                                     select c);
            return View();
        }




        // POST: Passengers_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "first_name,last_name,age,seat_no,passenger_id,booking_id,perhead_cost,status")] Passengers_Details passengers_Details,int seat_no)
        {
            
                if (ModelState.IsValid)
                {
                //TempData["booking_id"] = (from c in db.Passenger_booking_details
                //                          where c.passenger_id == 1
                //                          select c).OrderByDescending(c => c.booking_id).Take(1).SingleOrDefault();

                //TempData["booking_id"] = db.Passengers_Details.Find(Session["passenger_id"]);
                //Session["booking_id"]
                    TempData["seat_no"] = seat_no;
                    TempData["Name"] = passengers_Details.first_name + " " +passengers_Details.last_name;                
                    passengers_Details.passenger_id = (int)Session["passenger_id"];
                    passengers_Details.booking_id = (long)(TempData["booking_id"]);
                    passengers_Details.age = seat_no;
                    passengers_Details.seat_no = (int)((long)(TempData["booking_id"]) - 1000000);
                    var booking_id = (long)(TempData["booking_id"]);
                    db.Passengers_Details.Add(passengers_Details);
                    db.SaveChanges();

                //int flight_id = (int)TempData["flight_id"];
                //var seat_ava = (from c in db.Flights_Schedule where c.flight_id == flight_id
                //              select c).SingleOrDefault();
                //var bc_ava = seat_ava.bc_availability;

                //Flights_Schedule ava = new Flights_Schedule();
                //ava = db.Flights_Schedule.Find(TempData["flight_id"]);
                //db.Entry(ava).State = EntityState.Modified;
                //ava.bc_availability = bc_ava - 1;
                //db.SaveChanges();
                    //var res = db.display_ticket(booking_id);
                    var res = (from c in db.Passenger_booking_details
                               join p in db.Passengers_Details on c.booking_id equals p.booking_id
                               join s in db.Flights_Schedule on c.flight_id equals s.flight_id

                               where c.booking_id == passengers_Details.booking_id
                               select c);

                    //select new
                    //{
                    //    c.passenger_id,
                    //    c.booking_id,
                    //    c.Flights_Master.flight_name,
                    //    c.booking_Date,
                    //    c.journey_date,
                    //    c.Flights_Master.Routes_Master.Place.place_name,
                    //    p.first_name,
                    //    p.last_name,
                    //    p.age,
                    //    p.seat_no,
                    //    s.departure_time,
                    //    s.arrival_time,
                    //    s.duration
                    //});

                    return RedirectToAction("ShowBookedTicket", "BookingDetails");
                }
           
            //catch(Exception e)
            //{
            //    ModelState.AddModelError("");
            //}
            ViewBag.booking_id = new SelectList(db.Passenger_booking_details, "booking_id", "class", passengers_Details.booking_id);
            ViewBag.passenger_id = new SelectList(db.Passenger_Reg, "passenger_id", "title", passengers_Details.passenger_id);
            return View(passengers_Details);
        }

        //public ActionResult Seat_Combine()
        //{

        //    return PartialView(seatno_result);
        //}


        public ActionResult TicketQuery()
        {
           
            return View();
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

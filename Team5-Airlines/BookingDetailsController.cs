using Rash_Airlines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rash_Airlines.Controllers
{
    public class BookingDetailsController : Controller
    {
        Rash_AirlinesEntities db = new Rash_AirlinesEntities();
        // GET: BookingDetails
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Show_Tickets()
        {

            ViewBag.booking_id = new SelectList(db.Passenger_booking_details, "booking_id");
            //ViewBag.arr = new SelectList(db.Places, "place_id");
            return View();
        }

        [HttpPost]
        public ActionResult Show_Tickets(int booking_id)
        {


            var res = db.display_ticket(booking_id);
            if (res != null)
            {
                return View("Show_Tickets_list", res);
            }
            else
            {
                ModelState.AddModelError("", "No Flights Available");
            }
            return View();

        }
    }
}
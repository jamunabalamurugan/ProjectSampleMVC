using Rash_Airlines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rash_Airlines.Controllers
{
    public class SearchFlightController : Controller
    {
        Rash_AirlinesEntities db = new Rash_AirlinesEntities();
        // GET: SearchFlight
        public ActionResult Index_Search()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Search()
        {

            ViewBag.dep = new SelectList(db.Places, "place_id", "place_name");
            ViewBag.arr = new SelectList(db.Places, "place_id", "place_name");
            return View();
        }

        [HttpPost]
        public ActionResult Search(int dep, int arr, DateTime date)
        {


            //if (date > DateTime.Now)
            //{

                var res = db.search_flight2(dep, arr, date).ToList();
                if (res != null)
                {
                    return View("Search_Flight", res);
                }
                else
                {
                    ModelState.AddModelError("CustomError", "No Flights Available");
                    return View();
                }
            //}
            return View();
            

        }
        public ActionResult NoFlights()
        {
            return View();
        }
    }
}
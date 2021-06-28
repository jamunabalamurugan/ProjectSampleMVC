using Rash_Airlines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        [HandleError]
        [HttpGet]
        public ActionResult Search()
        {
            
            

                ViewBag.dep = new SelectList(db.Places, "place_id", "place_name");
                ViewBag.arr = new SelectList(db.Places, "place_id", "place_name");
                if (ViewBag.dep == null && ViewBag.arr == null)
                {

                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                }
 

            return View();
        }

        [HttpPost]
        public ActionResult Search(int? dep, int? arr, DateTime? date)
        {
            ViewBag.dep = new SelectList(db.Places, "place_id", "place_name");
            ViewBag.arr = new SelectList(db.Places, "place_id", "place_name");
            var res = db.search_flight2(dep, arr, date).ToList();
            if (res.Count != 0)
            {

                if (date > DateTime.Now)

                {
                    return View("Search_Flight", res);
                }
            }
            else
            {
                
                ModelState.AddModelError(string.Empty, "No Flights Available");
                //ModelState.AddModelError("date", "You can't enter the previous date");
                //return View();
            }
            return View();

        }


    }
     
    }

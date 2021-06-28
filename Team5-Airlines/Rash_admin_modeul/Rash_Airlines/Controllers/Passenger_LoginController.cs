using Rash_Airlines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rash_Airlines.Controllers
{
    public class Passenger_LoginController : Controller
    {
        // GET: Passenger_Login

        Rash_AirlinesEntities db = new Rash_AirlinesEntities();
        [HttpGet]
        public ActionResult Login_Passenger()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login_Passenger(Passenger_Reg login)
        {
            if (ModelState.IsValid)
            {
                var res = (from c in db.Passenger_Reg
                           where c.first_name == login.first_name && c.pwd == login.pwd
                           select c).SingleOrDefault();

                if (res != null)
                {
                    return RedirectToAction("Search", "SearchFlight");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid credentials");
                    return View();
                }
            }
            return View();
        }
    }
}
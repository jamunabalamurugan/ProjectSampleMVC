using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rash_Airlines.Models;

namespace Rash_Airlines.Controllers
{
    public class AdminController : Controller
    {
        Rash_AirlinesEntities db = new Rash_AirlinesEntities();
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin login)
        {
            if (ModelState.IsValid)
            {
                var res = (from c in db.Admins
                           where c.admin_username == login.admin_username && c.admin_password == login.admin_password
                           select c).SingleOrDefault();
            
                if (res != null)
                {
                    return RedirectToAction("Index_Schedule","Flights_Schedule");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid credentials");

                    return View();
                }

            }
            
            return View();
        }

    }
}
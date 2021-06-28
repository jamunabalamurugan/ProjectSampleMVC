using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL_Lakshya;
using BAL_Lakshya;

namespace Final_Lakshya.Controllers
{
    public class LakshyaHomeController : Controller
    {
        // GET: LakshyaHome
        public ActionResult Index()
        {
            return View();
        }
    }
}
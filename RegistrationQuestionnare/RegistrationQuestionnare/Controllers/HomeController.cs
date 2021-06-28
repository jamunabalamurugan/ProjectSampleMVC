using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationQuestionnare.Models;

namespace RegistrationQuestionnare.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        IRelaxEntities4 db = new IRelaxEntities4();
        public ActionResult Index()
        {
            ViewBag.loginflag = Session["loginflag"];
            string psno =Convert.ToString(Session["psno"]);
            Session["activitycount"] = 0;
            if(Convert.ToInt32(Session["loginflag"])==2)
            {
                DailyLoginTime record=db.DailyLoginTimes.Where(x => x.vEmpID == psno).FirstOrDefault();
                record.dLogoutTime = DateTime.Now;
                db.Entry(record).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                Session.Clear();
            }
            //dropdown notify 

            DateTime date1 = DateTime.Now.Date;
            //Pls include the line below after creating the db
            //var complete1 = db.TaskCompletionListForDay(psno, date1).ToList();
            //Session["model"] = complete1;
            return View();
        }
        [NoDirectAccess]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        [NoDirectAccess]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
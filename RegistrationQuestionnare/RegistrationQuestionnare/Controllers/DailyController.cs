using RegistrationQuestionnare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationQuestionnare.Controllers
{
    [HandleError]
    public class DailyController : Controller
    {
        IRelaxEntities4 db = new IRelaxEntities4();

        // GET: Daily
        [NoDirectAccess]
        public ActionResult Index()
        {
            return View();
        }
        #region Daily Activities
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ActivityID"></param>
        /// <returns></returns>
        [HttpGet]
        [NoDirectAccess]
        public ActionResult DailyActivities(int ActivityID=1)
        {
            try
            {
                Session["actid"] = ActivityID;
                ViewBag.daily = from act in db.DailyActivities select act;
                Session["activityflag"] = 1;
                return View();
            }
            catch (ArgumentException ae)
            {
                ViewBag.exception = "Argument Exception Occured";
                return View();
            }
            catch (NullReferenceException ne)
            {
                ViewBag.exception = "Null Reference Exception Occured";
                return View();
            }
            catch (IndexOutOfRangeException ie)
            {
                ViewBag.exception = "Index Out Of Range Exception Occured";
                return View();
            }
            catch (Exception e)
            {
                ViewBag.exception = "Exception Occured";
                return View();
            }
        }
        #endregion
    }
}
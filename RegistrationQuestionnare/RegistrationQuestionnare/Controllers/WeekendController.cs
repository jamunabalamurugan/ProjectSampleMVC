using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationQuestionnare.Models;
using RegistrationQuestionnare.Controllers;
using static RegistrationQuestionnare.Models.WeekendActivity;

namespace RegistrationQuestionnare.Controllers
{
    [HandleError]
    public class WeekendController : Controller
    {
        IRelaxEntities4 db = new IRelaxEntities4();
        // GET: Weekend
        //public ActionResult Index()
        //{
        //    ActivityModel act1 = new ActivityModel();
        //    using (DBModels db = new DBModels())
        //    {
        //        //  act1.Activities = db.WeekendActivities.ToList<WeekendActivity>();
        //        //act1.Activities = db.WeekendActivities.ToList<WeekendActivity>();
        //    }
        //    return View(act1);        
        //}
        #region Weekend Activities
            /// <summary>
            /// The weekend activites as per the preferences given by the user at the time of registration are displayed.
            /// </summary>
            /// <param name="ActivityID"></param>
            /// <returns></returns>
        [HttpGet]
        [NoDirectAccess]
        public ActionResult WeekendActivities(int ActivityID=1)
        {
            try
            {
                //Session["psno"] = "10662479";
                var stress = from employee in db.DailyLoginTimes
                             where employee.vEmpID == (Session["psno"]).ToString()
                             select Convert.ToInt32(employee.dbStressValue);
                string psno = Convert.ToString(Session["psno"]);

                var preferences = (from preference in db.WeekendEmployeeInterests
                                   where preference.vEmpID == psno
                                   select preference).Distinct();
                var preferenceList = new List<int?> { };
                //preferenceList.Add();
                foreach (var pref in preferences)
                {
                    preferenceList.Add(pref.iWActivityID);
                }
                Random random = new Random();
                int index = random.Next(1, preferenceList.Count);
                int value = Convert.ToInt32(preferenceList[index]);
                var places = from act in db.Places
                             where act.iWActivityID == ActivityID && act.vCity == "Chennai"
                             select act;

                ViewBag.places = places;

                ViewBag.weekends = from act in db.WeekendActivities select act;

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
using RegistrationQuestionnare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RegistrationQuestionnare.Controllers
{
    [HandleError]
    public class MainController : Controller
    {
        IRelaxEntities4 db = new IRelaxEntities4();
        // GET: Main
        [NoDirectAccess]
        public ActionResult Index()
        {
            return View();
        }
        #region Dashboard
        /// <summary>
        /// The timer for daily activities is initiated.
        /// Once the timer runs-out a daily activity is suggested via Pop-Up Notification.
        /// On clicking the Pop-Up notification, daily activities page is shown.
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        [HttpGet]
        [NoDirectAccess]
        public ActionResult Dashboard(int mid=3)
        {
            try
            {
                string psno = Convert.ToString(Session["psno"]);
                //Call Login Stored Procedure
                if (Session["loginflag"] == null)
                {
                    db.insert_login_time(Convert.ToString(Session["psno"]), mid);
                    var employee = from emp in db.EmployeePersonalDetails
                                   where emp.vEmpID == psno
                                   select emp;
                    foreach (var emp in employee)
                    {
                        Session["creditpoints"] = emp.iCreditPoints;
                    }
                    Session["loginflag"] = 1;
                }
                //Check if Activity is completed
                if (Convert.ToInt32(Session["activityflag"]) == 1)
                {
                    int count = Convert.ToInt32(Session["activitycount"]);
                    count++;
                    Session["activitycount"] = count;

                    db.insert_activity_track(Convert.ToString(Session["psno"]), Convert.ToInt32(Session["actid"]), Convert.ToDateTime(Convert.ToString(Session["starttime"])));

                    int creditpoints = Convert.ToInt32(Session["creditpoints"]);
                    creditpoints += 5;
                    Session["creditpoints"] = creditpoints;
                    EmployeePersonalDetail employee = db.EmployeePersonalDetails.Where(x => x.vEmpID == psno).FirstOrDefault();
                    employee.iCreditPoints = creditpoints;
                    db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Session["activityflag"] = 0;
                }
                //Session["psno"] = "10662455";

                var employees = from employee in db.DailyLoginTimes
                                where employee.vEmpID == psno
                                select employee;
                double stress = 4;
                foreach (var emp in employees)
                {
                    stress = Convert.ToDouble(emp.dbStressValue);
                }
                int timeinterval = 0;
                int stresslevel = 0;
                if ((stress >= 1) && (stress <= 2.3))
                {
                    stresslevel = 1;
                    timeinterval = 30000;
                }
                else if ((stress > 2.3) && (stress <= 3.6))
                {
                    stresslevel = 2;
                    timeinterval = 20000;
                }
                else if ((stress > 3.6) && (stress <= 5))
                {
                    timeinterval = 10000;
                    stresslevel = 3;
                }
                var activities = from act in db.DailyActivities
                                 where act.iStressMinLevel <= stresslevel
                                 select act;
                Random random = new Random();
                int activityid = random.Next(1, activities.Count());
                int counter = 0;
                foreach (var act in activities)
                {
                    counter++;
                    Session["actname"] = act.vDActivityName;
                    DateTime duration = Convert.ToDateTime(Convert.ToString(act.tDDuration));
                    int duration1 = duration.Minute;
                    duration1 *= 1000;
                    Session["duration"] = duration1;
                    Session["actid"] = act.iDActivityID;
                    if (counter == activityid)
                    {
                        break;
                    }
                }
                Session["stress"] = stress;
                Session["level"] = stresslevel;
                Session["timeinterval"] = timeinterval;

                Session["link"] = "http://localhost:52768/Daily/DailyActivities?ActivityID=" + Convert.ToString(Session["actid"]);
                Session["starttime"] = DateTime.Now;
                if (Convert.ToInt32(Session["actid"]) == 3)
                {
                    Session["link"] = "http://localhost:52768/GTB/StartGame";
                }
                //dropdown notify 

                DateTime date1 = DateTime.Now.Date;
                var complete1 = db.TaskCompletionListForDay(psno, date1).ToList();
                Session["model"] = complete1;

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
        #region My Space
        /// <summary>
        /// The user information is displayed based on the Employee ID.
        /// </summary>
        /// <returns></returns>
        [NoDirectAccess]
        public ActionResult Myspace()
        {
            try
            {
                string id = Convert.ToString(Session["psno"]);
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                EmployeePersonalDetail employeePersonalDetail = db.EmployeePersonalDetails.Find(id);
                if (employeePersonalDetail == null)
                {
                    return HttpNotFound();
                }
                return View(employeePersonalDetail);
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
        [NoDirectAccess]
        public ActionResult Logout()
        {
            try
            {
                Session["loginflag"] = 2;
                return RedirectToAction("Index", "Home");
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
    }
}
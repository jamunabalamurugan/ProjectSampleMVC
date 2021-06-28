using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineExamSystem.Models;

namespace OnlineExamSystem.Controllers
{
    [HandleError]
    public class AdminController : Controller
    {
        //GET: Admin
        OnlineExamSystemEntities2 db = new OnlineExamSystemEntities2();
        #region Admin Dashboard
        [HttpGet]
        public ActionResult AdminDashboard()
        {
            return View();
        }
        #endregion
        #region Add Questions
        /// <summary>
        /// Adds question to the database
        /// </summary>
        [HttpGet]
        public ActionResult AddQuestions()
        {
            ViewBag.TECHNOLOGies = db.TECHNOLOGies.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddQuestions(QUESTION q)
        {
            db.QUESTIONs.Add(q);
            db.SaveChanges();
            return RedirectToAction("AdditionSuccessful");
        }
        [HttpGet]
        public ActionResult AdditionSuccessful()
        {
            return View();
        }
        public ActionResult ViewQuestions()
        {
            return View(db.QUESTIONs.ToList());
        }
        /***************************************************************/
        #endregion
        #region Remove Questions
        /// <summary>
        /// Removes questoin from the database
        /// </summary>
        /// 
        [HttpGet]
        public ActionResult DeleteQuestions(int id)
        {
            QUESTION q = db.QUESTIONs.Find(id);
            return View(q);
        }
        [HttpPost]
        [ActionName("DeleteQuestions")]
        public ActionResult DeleteQuestionsConfirm(int id)
        {
            QUESTION q = db.QUESTIONs.Find(id);
            db.QUESTIONs.Remove(q);
            db.SaveChanges();
            return RedirectToAction("ViewQuestions");
        }
        /***************************************************************/
        #endregion
        #region Search Students & View Report
        /// <summary>
        /// Search students based on the conditions Admin gives
        /// </summary>
        /// <returns>Matching students' details</returns>
        [HttpGet]
        public ActionResult SearchStudents()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchStudents(ViewModel1 vm)
        {
            var tech = vm.TECHNOLOGY_NAME;
            Session["SessionReportTechnololgy"] = tech;
            var state = vm.STATE;
            Session["SessionReportState"] = state;
            var level = vm.TEST_LEVEL;
            Session["SessionReportLevel"] = level;
            var marks = vm.SCORE;
            Session["SessionReportMarks"] = marks;
            return RedirectToAction("ViewReport");            
        }
        [HttpGet]
        public ActionResult ViewReport(ViewModel1 vm)
        {
            var tech = Session["SessionReportTechnololgy"].ToString();
            var state = Session["SessionReportState"].ToString();
            var level = Convert.ToInt32(Session["SessionReportLevel"]);
            var marks = Convert.ToInt32(Session["SessionReportMarks"]);
            var result = (from c in db.USER_DETAIL
                          join l in db.REPORTs on c.USERID equals l.USERID
                          join t in db.TECHNOLOGies on l.TECHNOLOGY_ID equals t.TECHNOLOGY_ID
                          where t.TECHNOLOGY_NAME == tech
                          && c.STATE == state
                          && l.TEST_LEVEL == level
                          && l.SCORE == marks
                          select c).ToList();                     
            return View(result);
        }
        #endregion
    }
}
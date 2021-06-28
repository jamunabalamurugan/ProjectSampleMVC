using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineExamSystem.Models;
using System.Net;
using System.Net.Mail;

namespace OnlineExamSystem.Controllers
{
    [HandleError]
    public class UserController : Controller
    {
        // GET: User
        #region variables
        const int level_max = 3;
        OnlineExamSystemEntities2 db = new OnlineExamSystemEntities2();
        #endregion
        #region Home        
        public ActionResult Home()
        {
            return View();
        }
        #endregion
        #region About Us
        public ActionResult AboutUs()
        {
            return View();
        }
        #endregion
        #region Log in
        /// <summary>
        /// Logs the user and admin inside the application
        /// </summary>
        /// <returns>/// Returns to corresponding Dashboard/// </returns>
        [HttpGet]
        public ActionResult Login()
        {
            //Session["Email"] = db.USER_DETAIL
            return View();
        }
        [HttpPost]
        public ActionResult Login(USER_DETAIL ud)
        {
            Session["LoginStatus"] = false;
            var mail = ud.EMAIL;
            Session["SessionMail"] = mail;
            int userid = (from q in db.USER_DETAIL
                          where q.EMAIL == mail
                          select q.USERID).Single();
            Session["SessionUserId"] = userid;
            var fullname = (from q in db.USER_DETAIL
                            where q.EMAIL == mail
                            select q.FULL_NAME).Single();
            Session["SessionFullName"] = fullname;
            var pwd = ud.PASSWORD;
            var customer = db.USER_DETAIL.ToList();
            var res = (from i in db.USER_DETAIL where i.EMAIL == mail && i.PASSWORD == pwd select i).SingleOrDefault();
            if (res != null)
            {
                Session["LoginStatus"] = true;
                if (mail == "admin@gmail.com")
                {
                    return RedirectToAction("AdminDashboard", "Admin", new { area = "" });
                }
                else
                {
                    return RedirectToAction("UserDashboard");
                }
            }
            else
            {
                Session["LoginStatus"] = false;
                return View();
            }
        }
        #endregion
        #region User Dashboard
        [HttpGet]
        public ActionResult UserDashboard()
        {
            return View();
        }
        #endregion
        #region Registration
        /// <summary>
        /// Registers New User
        /// </summary>
        /// <returns>Home Action Method</returns>
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(USER_DETAIL u)
        {
            db.USER_DETAIL.Add(u);          
            db.SaveChanges();
            return RedirectToAction("RegistrationSuccessful");
        }
        [HttpGet]        
        public ActionResult RegistrationSuccessful()
        {
            return View();
        }
        [HttpPost]
        [ActionName("RegistrationSuccessful")]
        public ActionResult RegistrationSuccessfulPost()
        {
            return RedirectToAction("Home");
        }
        #endregion
        #region Before Test Begins...
        /// <summary>
        /// Lets user select technology and to take test on
        /// </summary>
        /// <returns>Takes user to the test page</returns>
         public ActionResult SelectTechnology()
         {
            ViewBag.TECHNOLOGies = db.TECHNOLOGies.ToList();
            return View();
         }

        [HttpPost]
        [ActionName("SelectTechnology")]
        public ActionResult SelectTechnologyPost(QUESTION T)
        {            
            var tech = Convert.ToInt32(Request.Form["TECHNOLOGY_ID"]);
            Session["Technology"] = tech;
            return RedirectToAction("TestInstructions");
        }
        [HttpGet]
        public ActionResult TestInstructions()
        {
            return View();
        }
        [HttpPost]
        [ActionName("TestInstructions")]
        public ActionResult TestInstructionsPost()
        {
            return RedirectToAction("Questions");
        }
        #endregion
        #region Test
        /// <summary>
        /// Test Logic
        /// </summary>
        /// <returns>Stores score in database and returns to report page</returns>
        [HttpGet]
        public ActionResult Questions()
        {
            var mail = Session["SessionMail"].ToString();
            int id = Convert.ToInt32(Session["Technology"]);
            int current_level = (from U in db.REPORTs
                                 where U.EMAIL == mail
                                 && U.TECHNOLOGY_ID == id
                                 && U.SCORE > 5
                                 select U).Count();
            int level=0;
            if (current_level > 3)
            {
                level = level_max;
            }
            else if (current_level <= 3)
            {
                level = current_level + 1;
            }
            else if (current_level == 0)
            {
                level = 1;
            }
            int tech = Convert.ToInt32(Session["Technology"]);            
            List<QUESTION> questions = (from Q in db.QUESTIONs
                                        where Q.TECHNOLOGY_ID == tech
                                        && Q.TEST_LEVEL == level
                                        select Q).ToList();
            Session["questions"] = questions;
            return View(questions);
        }
        [HttpPost]
        public ActionResult Questions(FormCollection f,QUESTION q)
        {
            REPORT r = new REPORT();
            List<QUESTION> right = new List<QUESTION>();            
            var mail = Session["SessionMail"].ToString();
            int id = Convert.ToInt32(Session["Technology"]);
            int current_level = (from U in db.REPORTs
                                 where U.EMAIL == mail
                                 && U.TECHNOLOGY_ID == id
                                 && U.SCORE > 5
                                 select U).Count();
            int level = 0;
            if (current_level > 3)
            {
                level = level_max;
            }
            else if (current_level <= 3)
            {
                level = current_level + 1;
            }
            else if (current_level == 0)
            {
                level = 1;
            }
            var ob = Request.Form["correctans"];
            Session["Level"] = level;
            int score_count=0;
            Session["Score"] = score_count;                
            var c = (from i in db.QUESTIONs
                     where i.TECHNOLOGY_ID == id
                     && i.TEST_LEVEL == level
                     select i.RIGHT_ANSWER).ToList();            
            int index = 0;
            int che;
            foreach(var i in c)
            {
                che = ob[index]-48;
                if(i == che)
                {
                    score_count += 1;                    
                }
                index = index + 2;
            }
            Session["Score"] = score_count;
            r.FULL_NAME = Session["SessionFullName"].ToString();
            r.USERID = Convert.ToInt32(Session["SessionUserId"]);
            r.TEST_LEVEL = level;
            r.TECHNOLOGY_ID = id;
            r.DATE_OF_EXAM = DateTime.Now;
            r.SCORE = score_count;
            r.EMAIL = Session["SessionMail"].ToString();
            db.REPORTs.Add(r);
            db.SaveChanges();
            return RedirectToAction("SubmitSuccess");
        }
        #endregion
        #region After Test Submit
        [HttpGet]
        public ActionResult SubmitSuccess()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SubmitSuccess(REPORT r)
        {            
            return RedirectToAction("ViewReport");
        }
        public ActionResult ViewReport()
        {

            var mail = Session["SessionMail"];
            List<REPORT> report = (from R in db.REPORTs
                                   orderby R.TEST_LEVEL
                                   where R.USER_DETAIL.EMAIL == mail.ToString()
                                   select R).ToList();
            return View(report);
        }
        #endregion
        #region Forgot Password
        /// <summary>
        /// Forgot Password logic
        /// </summary>
        /// <returns>Sends mail to the user with his password</returns>
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(USER_DETAIL f)
        {
            var email = f.EMAIL;
            var res = (from i in db.USER_DETAIL
                       where i.EMAIL == email
                       select i.PASSWORD).SingleOrDefault();
            if (res != null)
            {
                string to = "sangfroidshakthi@gmail.com";
                string from = "pika.b809@gmail.com";
                MailMessage message = new MailMessage(from, to);
                string mailbody = "Welcome To Techblast" + " <br />" + "Email id " + f.EMAIL + " <br />" + "Your Password: " + res;
                message.Subject = "Welcome";
                message.Body = mailbody;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential("pika.b809@gmail.com", "Jellybean123");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential1;
                try
                {
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction("Login", "User");
            }
            return View();
        }
        #endregion
        #region Logout
        /// <summary>
        /// Clears session and logs out the user
        /// </summary>
        /// <returns>Returns to Home page</returns>
        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.RemoveAll();
            Session.Clear();
            return RedirectToAction("Home", "User");
        }
        #endregion
    }
}
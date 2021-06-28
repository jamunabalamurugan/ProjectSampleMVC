using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using BAL_Lakshya;
using DAL_Lakshya;
using Final_Lakshya.Models;

namespace Final_Lakshya.Controllers
{
    public class UserController : Controller
    {
        LakshyaBALClass Lak_Bal_Obj = new LakshyaBALClass();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Add_User user)
        {
            if (user.User_Id.ToUpper() == "ADMIN")
            {
                if (user.Password.ToUpper() == "ADMIN")
                {
                    Session["UserName"] = user.User_Id.ToUpper();
                    return RedirectToAction("Session_Login");
                }
                else
                {
                    var message = "Invalid Password...!!!";
                    TempData["pass_invalid"] = message;
                }
            }
            else
            {
                var res = Lak_Bal_Obj.User_Login();
                foreach (var item in res)
                {
                    if (item.User_Id == user.User_Id.ToUpper())
                    {
                        if (item.Password == user.Password.ToUpper())
                        {
                            if (item.Mail_Status == false)
                            {
                                var message = "Email Not Activated...!!!";
                                TempData["Not_Active"] = message;
                            }
                            else
                            {
                                Session["Full_Name"] = item.Name;
                                Session["UserName"] = item.User_Id;
                                Session["Email"] = item.User_Email;
                                Session["Contact"] = item.Phone_No;
                                Session["DOB"] = item.DOB;
                                return RedirectToAction("Session_Login");
                            }
                        }
                        else
                        {
                            var message = "Invalid Password...!!!";
                            TempData["pass_invalid"] = message;
                        }
                    }
                    else
                    {
                        var message = "Invalid Username...!!!";
                        TempData["userid_invalid"] = message;
                    }
                }
            }
            return RedirectToAction("Session_Login");
        }

        [HttpGet]
        public ActionResult User_Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult User_Register(Add_User user)
        {
            db_Lakshay_OnlinetestEntities db = new db_Lakshay_OnlinetestEntities();
            var count_id = (from tbl_User in db.tbl_User select tbl_User).Count();
            string uid;
            if(count_id == 0)
            {
                uid = "LTI10652001";
            }
            else
            {
                var max_id = db.tbl_User.Max(x => x.User_Id);
                int new_id = Convert.ToInt32(max_id.Substring(max_id.Length-3));
                int new_id2 = (int)(Math.Log10((double)new_id) + 1);
                new_id++;
                if (new_id2==1)
                {
                    if (new_id == 10)
                    {
                        
                        uid = "LTI106520" + (new_id).ToString();
                    }
                    else
                    {
                        uid = "LTI1065200" + (new_id).ToString();
                    }
                }
                else if(new_id2==2)
                {
                    if (new_id == 100)
                    {
                        uid = "LTI10652" + (new_id).ToString();
                    }
                    else
                    {
                        uid = "LTI106520" + (new_id).ToString();
                    }
                }else
                {
                    uid = "LTI10652" + (new_id).ToString();
                }
                
            }

            tbl_User u = new tbl_User();
            u.User_Id = uid;
            u.Name = user.Name;
            u.User_Email = user.User_Email;
            u.Phone_No = user.Phone_No;
            u.Password = uid;
            u.DOB = user.DOB;
            u.Mail_Status = false;
         
            if(Lak_Bal_Obj.User_Register(u))
            {
                return RedirectToAction("success");
            }
           
            return View();
        }

        public ActionResult success()
        {
            return View();
        }

        public ActionResult User_Home()
        {
            ViewBag.FullName = Session["Full_Name"];
            ViewBag.UserName = Session["UserName"];
            ViewBag.email = Session["Email"];
            ViewBag.contact = Session["Contact"];
            ViewBag.dob = Session["DOB"];
            return View();
        }

        public ActionResult Session_Login()
        {

            if (Session["UserName"] == null)
            {
                    if (TempData["Not_Active"] != null)
                    {
                        ViewBag.Not_Active = TempData["Not_Active"];
                        return View();
                    }
                    else if (TempData["pass_invalid"] != null)
                    {
                        ViewBag.Password_Invalid = TempData["pass_invalid"];
                        return View();
                    }
                    else if (TempData["userid_invalid"] != null)
                    {
                        ViewBag.Id_Invalid = TempData["userid_invalid"];
                        return View();
                    }
                    else
                    {
                        return View();
                    }
            }
            else if (Session["UserName"].ToString() == "ADMIN")
            {
                return RedirectToAction("Admin_Home", "Admin");
            }
            else
            {
                return RedirectToAction("User_Home", "User");
            }
        }

        public ActionResult Logout()
        {
            Session["UserName"] = null;
            Session.Abandon();
            return RedirectToAction("Index", "LakshyaHome");
        }
    }
}
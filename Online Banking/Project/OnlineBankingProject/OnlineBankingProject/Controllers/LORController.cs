using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OnlineBankingProject.Models;

/// <summary>
/// In this Controller we have PageViews, UserLogin, OpenSavingsAccount, OnlineRegistration, 
/// ChangePassword, ForgotPassword, AdminLogin, AdminApproval and Logout.
/// </summary>
namespace OnlineBankingProject.Controllers
{
    [HandleError]
    public class LORController : Controller
    {
        // GET: Login
        OnlineBankingEntities db = new OnlineBankingEntities();

        #region PageViews  
        public ActionResult HomeBeforeLogin()
        {
            return View();
        }
        public ActionResult LoginLink()
        {
            return View();
        }
        public ActionResult HomePageBackground()
        {
            return View();
        }

        [Route("About")]
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult HomeAfterLogin()
        {
            try
            {
                var userId = Session["Ruser_Id"].ToString();
                var accNumberuser = (from i in db.Registration_table
                                     where i.Ruser_Id == userId
                                     select i).SingleOrDefault();
                long accNo = (long)accNumberuser.Account_Number;
                Session["Account_Number"] = accNo;
                return View();
            }
            catch (Exception e)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }
        #endregion


        #region Userlogin 
        [HttpGet]

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVm l)
        {

            var userid = l.Ruser_Id;
            var password = l.Login_Password;
            var customers = db.Registration_table.ToList();
            var res = (from i in customers
                       where i.Ruser_Id == userid &&
                        i.Login_Password == password
                       select i).SingleOrDefault();

            if (res != null)
            {
                Session["Ruser_Id"] = userid;
                return RedirectToAction("HomeAfterLogin");
            }
            else
            {
                return View();
            }

        }
        #endregion


        #region AdminLogin
        [HttpGet]
        public ActionResult AdminLogin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin l)
        {
            var Admin = l.AdminName;
            var password = l.Password;
            var admins = db.Admins.ToList();
            var res = (from i in admins
                       where i.AdminName == Admin &&
                        i.Password == password
                       select i).SingleOrDefault();

            if (res != null)
            {
                return RedirectToAction("AdminStatusApproval");
            }
            else
            {
                ViewBag.Message1 = "* Please Enter the correct UserName";
                ViewBag.Message2 = "* Please Enter the correct Password";
                return View();
            }

        }
        #endregion


        #region AdminApproval
        public ActionResult AdminStatusApproval(Open_Savings_Account o)
        {
            var aproveUser = (from i in db.Open_Savings_Account
                              where i.Approve_Status == null
                              select i).ToList();

            return View(aproveUser);

        }

        public ActionResult Approved(long? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var obj = db.Open_Savings_Account.Find(id);
                obj.Approve_Status = "Approved";
                Session["Email"] = obj.Email_Id;
                Session["Account_Number"] = obj.Account_Number;
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return View(obj);
            }
            catch (Exception e)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }
        public ActionResult GenerateEmail(long? id, string action = "Approved")
        {

            return View();

        }

        [HttpPost]
        public ActionResult GenerateEmail()
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var senderEmail = new MailAddress("snkbanking@gmail.com", "SNKBANK");
                    var receiverEmail = new MailAddress(Session["Email"].ToString(), "Receiver");
                    var password = "snkbank@123";
                    var subject = "Account Number Generated";
                    var body = "Your Account number is " + Session["Account_Number"].ToString() + "  has been Successfully Opened ";
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return RedirectToAction("AdminStatusApproval");
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }

        public ActionResult Delete(long? id)
        {
            try
            {
                var obj = db.Open_Savings_Account.Find(id);
                obj.Approve_Status = "Rejected";

                Session["Email"] = obj.Email_Id;
                Session["Account_Number"] = obj.Account_Number;
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return View(obj);
            }
            catch (Exception e)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }


        public ActionResult GenerateEmail2(long? id, string action = "Delete")
        {

            return View();

        }
        [HttpPost]
        public ActionResult GenerateEmail2()
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var senderEmail = new MailAddress("snkbanking@gmail.com", "SNKBANK");
                    var receiverEmail = new MailAddress(Session["Email"].ToString(), "Receiver");
                    var password = "snkbank@123";
                    var subject = "Account Number Generated";
                    var body = "Your Request For Opening Saving Account has been  Rejected!  Please Contact Bank Manager! ";
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return RedirectToAction("AdminStatusApproval");
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }
        #endregion


        #region OpenAccount

        public ActionResult SavingAccount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SavingAccount([Bind(Include = "First_Name,Last_Name,Father_Name,Mobile_Number,Email_Id,AadharCard_Number,Date_Of_Birth,Residential_Address_line1,Residential_Address_line2,Residential_Landmark,Residential_State,Residential_City,Residential_Pincode, Permanent_Address_Line1,Permanent_Address_Line2,Permanent_Landmark,Permanent_State,Permanent_City,Permanent_Pincode,Occupational_type,Source_Of_Income,Gross_Annual_Income,Balance")] Open_Savings_Account o)
        {
            //o.Approve_Status = "Not Approved";
            if (ModelState.IsValid)

            {
                db.Open_Savings_Account.Add(o);
                db.SaveChanges();
            }

            return RedirectToAction("HomeBeforeLogin");
        }
        #endregion


        #region OnlineRegistration
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(Register r)
        {
            string Ruser = r.Ruser_Id;
            long accNo = r.Account_Number;
            var adar = r.AadharCard_Number;
            var obj = (from j in db.Open_Savings_Account
                       where j.Account_Number == accNo && j.AadharCard_Number == adar
                       select j.Email_Id).FirstOrDefault();
            Session["Account_Number"] = r.Account_Number;
            Session["Ruser_Id"] = r.Ruser_Id;
            Session["Email_Id"] = obj.ToString();
            string numbers = "0123456789";
            Random objrandom = new Random();
            string strrandom = string.Empty;
            for (int i = 0; i < 5; i++)
            {
                int temp = objrandom.Next(0, numbers.Length);
                strrandom += temp;
            }

            //send otp to mail
            try
            {
                string emaijl = Session["Email_Id"].ToString();
                var senderEmail = new MailAddress("snkbanking@gmail.com", "SNKBANK");
                var receiverEmail = new MailAddress(Session["Email_Id"].ToString(), "Receiver");
                var password = "snkbank@123";
                var subject = "OTP Generated";
                var body = "your OTP is " + strrandom;
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(mess);
                }

            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            ViewBag.otp = strrandom;
            TempData["otp"] = strrandom;

            return RedirectToAction("RegisterConfirm");
        }
        public ActionResult RegisterConfirm()
        {

            return View();
        }

        [HttpPost]
        public ActionResult RegisterConfirm([Bind(Include = "Login_Password,Transaction_Password,OTP")]RegisterConfirm rc)
        {
            try
            {

                string aotp = TempData["otp"].ToString();
                string strrandom = rc.OTP;
                if (aotp.Equals(strrandom))
                {
                    Registration_table rt = new Registration_table();

                    rt.Account_Number = (long)Session["Account_Number"];
                    rt.Ruser_Id = Session["Ruser_Id"].ToString();
                    rt.Email_Id = Session["Email_Id"].ToString();
                    rt.Login_Password = rc.Login_Password;
                    rt.Transaction_Password = rc.Transaction_Password;
                    rt.Login_Password = Security.Encryptdata(rc.Login_Password);
                    rt.Transaction_Password = Security.Encryptdata(rc.Transaction_Password);
                    db.Registration_table.Add(rt);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }


            }
            catch (Exception e)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }

        #endregion


        #region RemoteValidation
        public bool IsExist(string Ruser_Id)
        {
            var result = (from user in db.Registration_table where user.Ruser_Id == Ruser_Id select user).ToList();
            if (result.Count != 0)
                return false;
            else
                return true;
        }
        public JsonResult IsRuser_IdExist(string Ruser_Id)
        {
            return IsExist(Ruser_Id) ? Json(true, JsonRequestBehavior.AllowGet) : Json(false, JsonRequestBehavior.AllowGet);
        }


        public bool IsExist(long Account_Number)
        {
            var result = (from user in db.Open_Savings_Account where user.Account_Number == Account_Number select user).ToList();
            if (result.Count != 0)
                return true;
            else
                return false;
        }

        public JsonResult IsAccount_NumberExist(string Account_Number)
        {
            return IsExist(Account_Number) ? Json(true, JsonRequestBehavior.AllowGet) : Json(false, JsonRequestBehavior.AllowGet);
        }

        public bool IssExist(string AadharCard_Number)
        {
            var result = (from user in db.Open_Savings_Account where user.AadharCard_Number == AadharCard_Number select user).ToList();
            if (result.Count != 0)
                return true;
            else
                return false;
        }

        public JsonResult IssAadharCard_NumberExist(string AadharCard_Number)
        {
            return IssExist(AadharCard_Number) ? Json(true, JsonRequestBehavior.AllowGet) : Json(false, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region ChangePassword
        public ActionResult ChangePassword()
        {
            var Accno = (long)Session["Account_Number"];
            var result = (from i in db.Registration_table
                          where i.Account_Number == Accno
                          select i).SingleOrDefault();

            return View(result);

        }
        [HttpPost]
        public ActionResult ChangePassword(Registration_table r)
        {
            try
            {
                db.Entry(r).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ChangePassword");


            }
            catch (Exception e)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }
        #endregion


        #region ChangePasswordValidation
        public bool IsExistt(string Email_Id)
        {
            var result = (from user in db.Open_Savings_Account where user.Email_Id == Email_Id select user).ToList();
            if (result.Count != 0)
                return true;
            else
                return false;
        }
        public JsonResult IsEmail_IdExistt(string Email_Id)
        {
            return IsExist(Email_Id) ? Json(true, JsonRequestBehavior.AllowGet) : Json(false, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region ForgotPassword
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ForgotPassword(Registration_table l)
        {
            var mail = l.Email_Id;
            var accno = l.Account_Number;
            var number = db.Registration_table.ToList();
            var res = (from i in db.Registration_table
                       where i.Email_Id == mail && i.Account_Number == accno
                       select i.Login_Password).SingleOrDefault();
            string pwd = res.ToString();
            string encrypt = Security.Decryptdata(pwd);
            if (res != null)
            {
                string to = l.Email_Id; //To address    
                string from = "snkbanking@gmail.com"; //From address    
                MailMessage message = new MailMessage(from, to);
                string mailbody = "Your Passwords is " + encrypt;
                message.Subject = "Hi";
                message.Body = mailbody;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                NetworkCredential basicCredential1 = new
                NetworkCredential("snkbanking@gmail.com", "snkbank@123");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential1;
                try
                {
                    client.Send(message);
                    Console.WriteLine(message);
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return RedirectToAction("Login");

        }
        #endregion


        #region Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("HomeBeforeLogin", "LOR");
        }
        #endregion

    }   
}



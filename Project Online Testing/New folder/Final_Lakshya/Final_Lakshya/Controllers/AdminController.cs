using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL_Lakshya;
using BAL_Lakshya;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Final_Lakshya.Controllers
{
    public class AdminController : Controller
    {
        LakshyaBALClass Lak_Bal_Obj = new LakshyaBALClass();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Admin_Home()
        {
            return View();
        }

        public ActionResult Login_Activation()
        {
            var res = Lak_Bal_Obj.User_Activate();
            
            return View(res);
        }
        
        public ActionResult Send_Mail(string id)
        {
            //string id = f["id"];
            var res = Lak_Bal_Obj.SendMail(id);
            foreach (var item in res)
            {
                try
                {
                    //if (ModelState.IsValid)
                    //{
                    var senderEmail = new MailAddress("lakshya.officials2018@gmail.com", "Lakshya");
                        var receiverEmail = new MailAddress(item.User_Email, "Receiver");
                        var password = "lakshya@google1234#";
                        var sub = "Lakshya Account Verification";
                        var body = "Hello "+item.Name+ ",<br />Welcome to Lakshya...!!!<br/><br/><br/>Your Lakshya Credentials are:-<br/>UserId: " +item.User_Id
                                            + "<br/>Password: "+item.Password+ "<br/><br/>Click on below link to activate your profile...!!!<br/>" +
                                            "http://localhost:49909/Admin/Activate_Mail?id="+item.User_Id;

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
                            Subject = sub,
                            Body = body
                        })
                        {
                            smtp.Send(mess);
                        }
                        return RedirectToAction("Admin_Home","Admin");
                //}
            }
                catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }
        }
            return RedirectToAction("Admin_Home","Admin");
        }

        public ActionResult Activate_Mail(string id)
        {

            if (Lak_Bal_Obj.Mail_Status_Update(id))
                return RedirectToAction("Index","LakshyaHome");
            else
            {
                ViewBag.msg = "Error in Activating Mail";
                return View();
            }
            
                
        }

    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using projectOnlineShopping.Models;

namespace projectOnlineShopping.Controllers
{
    [HandleError]
    public class registrationTablesController : Controller
    {
        private onlineShoppingEntities db = new onlineShoppingEntities();
        bool result;
        string mailbody, to, from;


        #region Register
        /// <summary>
        /// New user can register himself
        /// </summary>
        /// <returns>Login Page</returns>
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "phoneNo,Password,cnpass,name,emailId,address")] registrationTable registrationTable)
        {
            if (ModelState.IsValid)
            {
                //registrationTable.Password = Security.HashSHA1(registrationTable.Password);
                //registrationTable.cnpass = Security.HashSHA1(registrationTable.cnpass);

                db.registrationTables.Add(registrationTable);
                db.SaveChanges();

                Response.Write("<script>alert('Registered')</script>");
                return RedirectToAction("loginPage","registrationTables");
            }
           

             return View();
        }
        #endregion



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



        #region Login Page
        /// <summary>
        /// User can login into the application
        /// </summary>
        /// <returns>Home</returns>
        public ActionResult loginPage()
        {
           
           

            return View();
        }
        [HttpPost]
        public ActionResult loginPage(LoginVM t)
        {
            Session["UserId"] = t.phoneNo;
            var customers = db.registrationTables.ToList();
            var res = (from i in db.registrationTables
                       where i.phoneNo == t.phoneNo &&
                       i.Password == t.Password
                       select i).SingleOrDefault();
            result = false;

            var name = (from i in db.registrationTables
                       where i.phoneNo == t.phoneNo 
                       select i.name).SingleOrDefault();

            Session["name"] = name;
         



            if (res != null)
            {
               
                result = true;
                Session["result"] = result;

                if (Convert.ToBoolean(Session["cartViewLogin"]) == true)
                {
                    return RedirectToAction("productDescription", "products", new { id = Session["currId"], catId = Session["CatogId"] });
                }
                else if(Convert.ToBoolean(Session["placeOrder"]) == true)
                {
                    return RedirectToAction("productDescription", "products", new { id = Session["currId"], catId = Session["CatogId"] });
                }
                else if(Convert.ToBoolean(Session["placeOrderInCart"])==true)
                {
                    return RedirectToAction("productDescription", "products", new { id = Session["currId"], catId = Session["CatogId"] });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                

            }
            else
            {
                result = false;
                Session["result"] = result;
         
                Response.Write("User Id or Password is invalid");
                return View();

                

            }
           
        }
        #endregion



        #region Forget Password
        /// <summary>
        /// Resetting of password when user forgets his/her password
        /// </summary>
        /// <returns>Login Page</returns>
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(registrationTable f)
        {
            var CustEmail = f.emailId;
          
            var res = (from i in db.registrationTables
                       where i.emailId == CustEmail
                       select i.Password).SingleOrDefault();
            if (res != null)

            {

                to = "dharsinivel@gmail.com"; //To address    
                from = "pika.b809@gmail.com"; //From address    
                MailMessage message = new MailMessage(from, to);

                mailbody = "Welcome To Grand Embassy" + " <br />" + "Email id " + f.emailId + " <br />" + "Your Password: " + res;
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
                return RedirectToAction("loginPage", "registrationTables");
            }
            return View();
        }
        #endregion


        #region Logout
        /// <summary>
        /// All the sessions are cleared when user logs off
        /// </summary>
        /// <returns>Home page</returns>
        public ActionResult logout()
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }
        #endregion
    }

}


using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineBankingProject.Models;


/// <summary>
/// DashBoard Controllers have Account Details , Account Statement, Addnew Beneficiary, 
/// Transaction Login, Transaction Types, View Profile and  AdminViews.
/// </summary>

namespace OnlineBankingProject.Controllers
{
    [HandleError]
    public class DashBoardController : Controller
    {
    
        // GET: DashBoard
        OnlineBankingEntities db = new OnlineBankingEntities();

        #region AccountDetails
        [Route("AccountDetails")]
        public ActionResult AccountDetails(int? id)
        {
            var Accno =(long) Session["Account_Number"];
            var result = (from i in db.Open_Savings_Account
                          where i.Account_Number == Accno
                          select i).SingleOrDefault();
          
           return View(result); 
        }
        #endregion


        #region AccountStatement
        public ActionResult AccountStatement()
        {
            var Accno = (long)Session["Account_Number"];
            var result = (from i in db.Transaction_Table
                          where i.Account_Number == Accno
                          select i).ToList();

            return View(result);
           
        }

        [HttpGet]
        public ActionResult Statement(string FromDate, string ToDate)
        {
            try
            {
                DateTime fdate = DateTime.ParseExact(FromDate, "dd/MM/yyyy", null);
                DateTime tdate = DateTime.ParseExact(ToDate, "dd/MM/yyyy", null);
                var Accno = (long)Session["Account_Number"];
                var transactiontime = (from i in db.Transaction_Table
                                       where i.Account_Number == Accno
                                       where i.Transaction_Date >= fdate &&
                                       i.Transaction_Date <= tdate
                                       select i).ToList();
                return View(transactiontime);
            }
            catch (Exception e)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }
        #endregion


        #region AddNewBeneficiary
        [HttpGet]
        public ActionResult AddNewBeneficiary()
        {

            return View();

        }
        [HttpPost]
        public ActionResult AddNewBeneficiary([Bind(Include = "Beneficiary_Name,Beneficiary_Account_Number,Nick_Name")] Beneficiary_Table o)
        {
            try {
                if (ModelState.IsValid)

                {
                    var Accno = (long)Session["Account_Number"];
                    var NewBeneficiary = (from i in db.Registration_table
                                          where i.Account_Number == Accno
                                          select i).SingleOrDefault();

                    o.Account_Number = Accno;
                    db.Beneficiary_Table.Add(o);
                    db.SaveChanges();
                    return RedirectToAction("HomeAfterLogin", "LOR");
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }

        public bool IsExist(long Beneficiary_Account_Number)
        {
            var result = (from user in db.Beneficiary_Table where user.Beneficiary_Account_Number == Beneficiary_Account_Number select user).ToList();
            if (result.Count != 0)
                return false;
            else
                return true;
        }
        public JsonResult IsBeneficiary_Account_NumberExist(long Beneficiary_Account_Number)
        {
            return IsExist(Beneficiary_Account_Number) ? Json(true, JsonRequestBehavior.AllowGet) : Json(false, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region TransactionLogin
        public ActionResult TransactionLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TransactionLogin(TransactionLogin tl)
        {
            try {
                var userid = tl.Ruser_Id;
                var password = tl.Transaction_Password;
                var customers = db.Registration_table.ToList();
                var res = (from i in customers
                           where i.Ruser_Id == userid &&
                            i.Transaction_Password == password
                           select i).SingleOrDefault();

                if (res != null)
                {
                    Session["Ruser_Id"] = userid;
                    return RedirectToAction("Transaction");
                }
                else
                {
                    return View();
                }

            }
            catch (Exception e)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }

        #endregion


        #region TransactionTypes
        public ActionResult Transaction()
        {   
            return View();
        }
 

        [HttpGet]
        public ActionResult Imps( )
        {
            var Accno = (long)Session["Account_Number"];
            ViewBag.BeneficiaryI = (from i in db.Beneficiary_Table
                                     where i.Account_Number == Accno
                                     select i).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Imps(Imps im, Transaction_Table i)
        {
            try
            {
                int tran = Convert.ToInt32(i.Transaction_Amount);
                long Account_Number1 = (long)Session["Account_Number"];
                var obj = (from j in db.Open_Savings_Account
                           where j.Account_Number == Account_Number1
                           select j).FirstOrDefault();
                obj.Balance = obj.Balance - tran;
                i.Transaction_Date = DateTime.Now;
                i.Account_Number = Account_Number1;
                i.Transaction_Mode = "IMPS";
                db.Transaction_Table.Add(i);
                db.SaveChanges();
                return RedirectToAction("Transaction");

            }

            catch (Exception e)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }

            public ActionResult Neft()
        {
            var Accno = (long)Session["Account_Number"];
            ViewBag.BeneficiaryA = (from i in db.Beneficiary_Table
                                     where i.Account_Number == Accno
                                     select i).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Neft(Neft n, Transaction_Table t)
        {

            try
            {
                int tran = Convert.ToInt32(t.Transaction_Amount);
                long Account_Number1 = (long)Session["Account_Number"];
                var obj = (from j in db.Open_Savings_Account
                           where j.Account_Number == Account_Number1
                           select j).FirstOrDefault();
                obj.Balance = obj.Balance - tran;
                t.Transaction_Date = DateTime.Now;
                t.Account_Number = Account_Number1;
                t.Transaction_Mode = "NEFT";
                db.Transaction_Table.Add(t);
                db.SaveChanges();
                return RedirectToAction("Transaction");

            }
            catch (Exception e)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }


        [HttpGet]
        public ActionResult Rtgs()
        {
            var Accno = (long)Session["Account_Number"];
            ViewBag.BeneficiaryR = (from i in db.Beneficiary_Table
                                     where i.Account_Number == Accno
                                     select i).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Rtgs(Rtgs rg, Transaction_Table tb)
        {
            try
            {

                int tran = Convert.ToInt32(tb.Transaction_Amount);
                long Account_Number1 = (long)Session["Account_Number"];
                var obj = (from j in db.Open_Savings_Account
                           where j.Account_Number == Account_Number1
                           select j).FirstOrDefault();
                obj.Balance = obj.Balance - tran;
                tb.Transaction_Date = DateTime.Now;
                tb.Account_Number = Account_Number1;
                tb.Transaction_Mode = "RTGS";
                db.Transaction_Table.Add(tb);
                db.SaveChanges();
                return RedirectToAction("Transaction");
            }
            catch (Exception e)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }

            //public ActionResult TransactionReceipt()
            //{
            //    var Accno = (long)Session["Account_Number"];
            //    var result = (from i in db.Transaction_Table
            //                  where i.Account_Number == Accno
            //                  select i).ToList();

            //    return View(result);

            //}

            #endregion


        #region ViewProfile
            public ActionResult ViewProfile()
        {
            long? Accno = (long)Session["Account_Number"];
            var result = (from i in db.Open_Savings_Account
                          where i.Account_Number == Accno
                          select i).SingleOrDefault();

           return View(result);
        }

        [HttpPost]
        public ActionResult ViewProfile(Open_Savings_Account p)
        {
            try
            {
                db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewProfile");
            }
            catch (Exception e)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }
            #endregion


        #region AdminViews

            public ActionResult Open_Savings_Account()
        {

            return View(db.Open_Savings_Account.ToList());
        }

    
        public ActionResult Registration_table()
        {

            return View(db.Registration_table.ToList());
        }

        #endregion

    }
}
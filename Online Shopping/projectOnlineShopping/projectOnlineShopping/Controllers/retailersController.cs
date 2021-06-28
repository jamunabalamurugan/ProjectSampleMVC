using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projectOnlineShopping.Models;

namespace projectOnlineShopping.Controllers
{
    [HandleError]
    public class retailersController : Controller
    {
        private onlineShoppingEntities db = new onlineShoppingEntities();



        #region Admin Login
        /// <summary>
        /// Admin can Login into the application
        /// </summary>
        /// <returns>List of choices</returns>
        public ActionResult adminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult adminLogin(adminVM t)
        {
            var admin = db.adminTables.ToList();
            var res = (from i in db.adminTables
                       where i.adminId == t.adminId &&
                       i.adminPassword == t.adminPassword
                       select i).SingleOrDefault();
            bool adminResult = false;
            if (res != null)
            {
                adminResult = true;
                Session["adminRes"] = adminResult;
               

                return RedirectToAction("choices", "retailers");
            }
            else
            {
                adminResult = false;
                Session["adminRes"] = adminResult;
                Response.Write("Invalid Id or Password");
                return View();
            }
        }
        #endregion


        #region Admin's choices
        /// <summary>
        /// Admin can delete or add a retailer
        /// </summary>
        /// <param name="t"></param>
        /// <returns>Updated retailer details</returns>
        public ActionResult choices(adminVM t)
        {
            return View();
        }
        #endregion



        #region List of Retailers
        /// <summary>
        /// List of all retailers under the admin are displayed
        /// </summary>
        /// <returns>List of retailers</returns>
        public ActionResult Index()
        {
            return View(db.retailers.ToList());
        }
        #endregion


        #region Details of a specific Retailer
        /// <summary>
        /// Entire details of the selected retailer is displayed
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retailer's Details</returns>
        public ActionResult Details(int? id)
        {
            Session["retToDel"] = id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            retailer retailer = db.retailers.Find(id);
            if (retailer == null)
            {
                return HttpNotFound();
            }
            return View(retailer);
        }
        #endregion


        #region Add new Retailer
        /// <summary>
        /// Admin can add new retailers
        /// </summary>
        /// <returns>Retailer's List</returns>
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "retailerId,phoneNo,Password,cnpass,name,emailId,address")] retailer retailer)
        {
            if (ModelState.IsValid)
            {
                db.retailers.Add(retailer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(retailer);
        }
        #endregion



        #region Edit details
        /// <summary>
        /// Admin can edit the details of a retailer
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Updated Retailer's Details </returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            retailer retailer = db.retailers.Find(id);
            if (retailer == null)
            {
                return HttpNotFound();
            }
            return View(retailer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "retailerId,phoneNo,Password,name,emailId,address")] retailer retailer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(retailer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(retailer);
        }
        #endregion



        #region Delete a Retailer
        /// <summary>
        /// Admin can delete a retailer
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Updated List</returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            retailer retailer = db.retailers.Find(id);
            if (retailer == null)
            {
                return HttpNotFound();
            }
            return View(retailer);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List<productDescription> del = (from i in db.productDescriptions
                                            where i.retailerId == id
                                            select i).ToList();            

            foreach (productDescription pd in del)
            {
               
                db.productDescriptions.Remove(pd);
            }
            retailer retailer = db.retailers.Find(id);     
            db.retailers.Remove(retailer);
            db.SaveChanges();
            return RedirectToAction("Index");
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
    }
}

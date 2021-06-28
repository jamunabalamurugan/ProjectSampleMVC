using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projectOnlineShopping.Models;
using System.IO;

namespace projectOnlineShopping.Controllers
{
    [HandleError]
    public class productDescriptionsController : Controller
    {
        string myfilename, extension, myfilename2, extension2, myfilename3, extension3;
        bool retLogResult;
        private onlineShoppingEntities db = new onlineShoppingEntities();
        #region List of Products for the selected Retailer is displayed
        /// <summary>
        /// All the Products with full description for selected Retailer is displayed 
        /// </summary>
        /// <returns>List of Products</returns>
        public ActionResult Index()
        {
            ViewBag.ik = Session["retailerId"];
            var productDescriptions = db.productDescriptions.Include(p => p.categoryDetail).Include(p => p.retailer);
            return View(db.productDescriptions.ToList());
        }
        #endregion


        #region One product's entire details
        /// <summary>
        /// The selected product's entire details is displayed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productDescription productDescription = db.productDescriptions.Find(id);
            if (productDescription == null)
            {
                return HttpNotFound();
            }
            return View(productDescription);
        }
        #endregion


        #region Insert Product
        /// <summary>
        /// Retailer can insert his/her Product into the database
        /// </summary>
        /// <returns>List of Products </returns>
        public ActionResult Create()
        {
            ViewBag.categoryId = new SelectList(db.categoryDetails, "categoryId", "categoryName");
            ViewBag.retailerId = new SelectList(db.retailers, "retailerId", "phoneNo");
            return View();
        }
       

        [HttpPost]
        public ActionResult Create(productDescription productDescription, HttpPostedFileBase ImageUpload1, HttpPostedFileBase ImageUpload2, HttpPostedFileBase ImageUpload3)
        {

          
            if (ModelState.IsValid)
            {

                myfilename = Path.GetFileNameWithoutExtension(ImageUpload1.FileName);
                extension = Path.GetExtension(ImageUpload1.FileName);
                myfilename = myfilename + extension;
                productDescription.backImage = "~/image/" + myfilename;
                myfilename = Path.Combine(Server.MapPath("~/image/"), myfilename);
                ImageUpload1.SaveAs(myfilename);







                myfilename2 = Path.GetFileNameWithoutExtension(ImageUpload2.FileName);
                extension2 = Path.GetExtension(ImageUpload2.FileName);
                myfilename2 = myfilename2 + extension2;
                productDescription.frontImage = "~/image/" + myfilename2;
                myfilename2 = Path.Combine(Server.MapPath("~/image/"), myfilename2);
                ImageUpload2.SaveAs(myfilename2);








                myfilename3 = Path.GetFileNameWithoutExtension(ImageUpload3.FileName);
                extension3 = Path.GetExtension(ImageUpload3.FileName);
                myfilename3 = myfilename3 + extension3;
                productDescription.sideImage = "~/image/" + myfilename3;
                myfilename3 = Path.Combine(Server.MapPath("~/image/"), myfilename3);
                ImageUpload3.SaveAs(myfilename3);















                db.productDescriptions.Add(productDescription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryId = new SelectList(db.categoryDetails, "categoryId", "categoryName", productDescription.categoryId);
            ViewBag.retailerId = new SelectList(db.retailers, "retailerId", "phoneNo", productDescription.retailerId);
            return View(productDescription);
        }
        #endregion



        #region Editing the existing Product's details
        /// <summary>
        /// Retailer can edit details of his/her Products
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Updated List</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productDescription productDescription = db.productDescriptions.Find(id);
            if (productDescription == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryId = new SelectList(db.categoryDetails, "categoryId", "categoryName", productDescription.categoryId);
            ViewBag.retailerId = new SelectList(db.retailers, "retailerId", "phoneNo", productDescription.retailerId);
            return View(productDescription);
        }    



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "itemId,categoryId,productName,productDescription1,stock,color,backImage,frontImage,sideImage,rating,actualCost,discount,currentCost,brand,size,approvalStatus,retailerId")] productDescription productDescription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productDescription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryId = new SelectList(db.categoryDetails, "categoryId", "categoryName", productDescription.categoryId);
            ViewBag.retailerId = new SelectList(db.retailers, "retailerId", "phoneNo", productDescription.retailerId);
            return View(productDescription);
        }
        #endregion


        #region Delete Products
        /// <summary>
        /// Retailer can delete a product from his/her existing list
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Updated List</returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productDescription productDescription = db.productDescriptions.Find(id);
            if (productDescription == null)
            {
                return HttpNotFound();
            }
            return View(productDescription);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productDescription productDescription = db.productDescriptions.Find(id);
            db.productDescriptions.Remove(productDescription);
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


        #region Retailer Login
        /// <summary>
        /// Retailer can login into the application and can make changes
        /// </summary>
        /// <returns>Retailer's Page</returns>
        public ActionResult retLogin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult retLogin(LoginVM t)
        {
            var retailer = db.retailers.ToList();
            retailer r = new retailer();
            var res = (from i in db.retailers
                       where i.phoneNo == t.phoneNo &&
                       i.Password == t.Password
                       select i).SingleOrDefault();


            var retName = (from i in db.retailers
                        where i.phoneNo == t.phoneNo
                        select i.name).SingleOrDefault();

            Session["retName"] = retName;



            retLogResult = false;
            if (res != null)
            {
                retLogResult = true;
                Session["retLogRes"] = retLogResult;
                var id = (from i in db.retailers
                          where i.phoneNo == t.phoneNo
                          select i.retailerId).SingleOrDefault();
                Session["retailerId"] = id;

                return RedirectToAction("choices", "productDescriptions");
            }
            else
            {
                retLogResult = false;
                Session["retLogRes"] = retLogResult;
                Response.Write("Invalid Id or Password");
                return View();
            }
        }
        #endregion


        #region Navigation Between choices
        /// <summary>
        /// Retailer can navigate between the choices
        /// </summary>
        /// <returns>Choices</returns>
        public ActionResult  choices()
        {
            return View();
        }
        #endregion

    }
}

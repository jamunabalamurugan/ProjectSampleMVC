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
    
    public class orderTablesController : Controller
    {
        
        private onlineShoppingEntities db = new onlineShoppingEntities();
        //string todaysDate,customerId;
        public int totalPrice;

        #region To place the Order
        /// <summary>
        /// When the User wishes to buy a product,all the details are displayed. Order is placed and Stock value is decremented
        /// </summary>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public ActionResult order(int? price,int? quantity)
        {
            // DateTime cus price Session["UserId"]
            Session["quantity"] = 1;
            Session["price"] = price;
            Session["todaysDate"] = DateTime.Now.ToString();
            
            totalPrice = Convert.ToInt32(Session["quantity"]) * Convert.ToInt32(Session["price"]);
            ViewBag.totalprice = totalPrice;
            Session["totalPrice"] = totalPrice;
            return View();
        }
        [HttpPost]
        public ActionResult order(orderTable ot)
        {
            int currentItemId = Convert.ToInt32(Session["currId"]);

            ot.orderDate = Convert.ToDateTime(Session["todaysDate"]);
            ot.customerId = Session["UserId"].ToString();        
            ot.totalPrice = Convert.ToInt32(Session["price"]);
            db.orderTables.Add(ot);
            db.SaveChanges();

 

            var updateStock = (from i in db.productDescriptions
                               where i.itemId == currentItemId
                               select i.stock).SingleOrDefault();
   
            updateStock = updateStock - Convert.ToInt32(Session["quantity"]);
            productDescription productDescription = db.productDescriptions.Find(Convert.ToInt32(Session["currId"]));
            productDescription.stock = updateStock;
            db.Entry(productDescription).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("successful", "products");
        }

        public ActionResult placeCartOrder()
        {
          
            
           
            return View();
        }
        [HttpPost]
        public ActionResult placeCartOrder(orderTable ot)
        {
            
            ot.orderDate = Convert.ToDateTime(Session["todaysDate"]);
            ot.customerId = Session["UserId"].ToString();
            ot.totalPrice = Convert.ToInt32(Session["TotalCartPrice"]);
            db.orderTables.Add(ot);
            db.SaveChanges();
            return RedirectToAction("successful", "products");
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

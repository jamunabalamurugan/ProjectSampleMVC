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
    interface Icartspecific
    {
        ActionResult cartSpecific();
    }

    [HandleError]
    public class cartsController : Controller,Icartspecific
    {
        private onlineShoppingEntities db = new onlineShoppingEntities();
        int cartitemmid;

        #region To view Cart
        /// <summary>
        /// To view the cart of the user who has logged in
        /// </summary>
        /// <returns> List of his/her Cart Details </returns>
        public ActionResult cartSpecific()
        {
            ViewBag.cartSpecific = Session["UserId"];
            return View(db.carts.ToList());
        }
        #endregion



        #region Add to Cart
        /// <summary>
        /// To add a product to the User's Cart
        /// </summary>
        /// <returns>Product is added to Cart </returns>
        public ActionResult addCart()
        {
            ViewBag.cartUserId = Session["UserId"];

            cartitemmid = Convert.ToInt32(Session["currId"]);
            ViewBag.cartItemId = cartitemmid;
            return View(db.productDescriptions.ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addCart(cart cart)
        {
                var cartUserId = Session["UserId"];
                var cartItemId = Session["currId"];
                cart.userId = cartUserId.ToString();
                cart.itemId = Convert.ToInt32(cartItemId);                             
                
                db.carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("cartSpecific");
        }
        #endregion



        #region To Delete a Record in the Cart
        /// <summary>
        /// When user doesn't need an item in the Cart, He/She can delete that particular Item from the Cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The Cart after the deletion of that particular Item </returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cart cart = db.carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cart cart = db.carts.Find(id);
            db.carts.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("cartSpecific");
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

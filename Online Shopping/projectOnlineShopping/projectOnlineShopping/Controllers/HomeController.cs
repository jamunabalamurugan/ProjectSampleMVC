using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projectOnlineShopping.Models;

namespace projectOnlineShopping.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private onlineShoppingEntities db = new onlineShoppingEntities();
        int num;

        public ActionResult shirt()
        {

            List<productDescription> li = new List<productDescription>();

            //var twos = db.productDescriptions.ToList().Where((c, i) => i % 2 == 0);
            //var three = db.productDescriptions.ToList().Where((c, i) => i % 3 == 0);
            //var fours = db.productDescriptions.ToList().Where((c, i) => i % 4 == 0);
            //var fives = db.productDescriptions.ToList().Where((c, i) => i % 5 == 0);
           // li.Add(twos);
            return View(/*twos,three,fours,fives*/);
        }


        public ActionResult knowMore()
        {
            return View();
        }


        #region searching
        /// <summary>
        /// User can search a product
        /// </summary>
        /// <param name="searching"></param>
        /// <returns>selected product</returns>
        public ActionResult Index(string searching)
        {
            //Session["result"] = false;
            ViewBag.option = Session["result"];
               
                if (searching == "shirts" || searching == "shirt" || searching == "Shirts" || searching == "Shirt" || searching == "shirt" || searching == "dress" || searching == "Dress" )
                {
                    num = 101;
                    searching = Convert.ToString(num);
                    return RedirectToAction("shirts", "products");
                }
                if (searching == "kurtis" || searching == "kurti" || searching == "Kurtis" || searching == "Kurti" || searching == "kurthis" || searching == "Kurthis" || searching == "Kurthi" || searching == "kurthi")
            {
                    num = 102;
                    searching = Convert.ToString(num);
                    return RedirectToAction("kurthis", "products");
                }
                if (searching == "pant" || searching == "pants" || searching == "Pants" || searching == "Pant")
                {
                    num = 103;
                    searching = Convert.ToString(num);
                    return RedirectToAction("pants", "products");
                }
                if (searching == "saree" || searching == "sarees" || searching == "Sarees" || searching == "Saree")
                {
                    num = 104;
                    searching = Convert.ToString(num);
                    return RedirectToAction("sarees", "products");
                }
                if (searching == "kidswear" || searching == "kids wear" || searching == "Kidswear" || searching == "Kids wear" || searching == "Kid dress" || searching == "Kids" || searching == "kids")
            {
                    num = 105;
                    searching = Convert.ToString(num);
                    return RedirectToAction("kidsWear", "products");
                }
                if (searching == "tv" || searching == "television" || searching == "Television" || searching == "Tv")
                {
                    num = 201;
                    searching = Convert.ToString(num);
                    return RedirectToAction("tv", "products");
                }
                if (searching == "washingmachine" || searching == "washing machine" || searching == "Washingmachine" || searching == "Washing machine" || searching == "Washing Machine")
                {
                    num = 202;
                    searching = Convert.ToString(num);
                    return RedirectToAction("washingMachine", "products");
                }
                if (searching == "phone" || searching == "Phone" || searching == "mobile phone" || searching == "mobilephone" || searching == "Mobile phone" || searching == "Mobile Phone" || searching == "MobilePhone" || searching == "mobilePhone" || searching == "mobile Phone")
                {
                    num = 203;
                    searching = Convert.ToString(num);
                    return RedirectToAction("mobilePhone", "products");
                }
                if (searching == "microwaveoven" || searching == "Microwaveoven" || searching == "oven" || searching == "Oven")
                {
                    num = 204;
                    searching = Convert.ToString(num);
                    return RedirectToAction("microwaveOven", "products");
                }
                if (searching == "laptop" || searching == "Laptop" || searching == "lap" || searching == "Lap")
                {
                    num = 205;
                    searching = Convert.ToString(num);
                    return RedirectToAction("laptop", "products");
                }
                if (searching == "kidbooks" || searching == "kid books" || searching == "KidBooks" || searching == "Kid Books" || searching == "Kid books" || searching == "kid Books" || searching == "Kidbooks" || searching == "kidBooks")
                {
                    num = 301;
                    searching = Convert.ToString(num);
                    return RedirectToAction("kidsBook", "products");
                }
                if (searching == "fantacy fiction" || searching == "fantacyfiction" || searching == "fantacyFiction" || searching == "fantacy Fiction" || searching == "Fantacy fiction" || searching == "Fantacyfiction" || searching == "Fantacy Fiction" || searching == "FantacyFiction")
                {
                    num = 302;
                    searching = Convert.ToString(num);
                    return RedirectToAction("fantacyFiction", "products");
                }
                if (searching == "indian fiction" || searching == "indianfiction" || searching == "Indian Fiction" || searching == "IndianFiction" || searching == "indian Fiction" || searching == "indianFiction" || searching == "Indian fiction" || searching == "Indianfiction" || searching == "books" || searching == "Books")
            {
                    num = 303;
                    searching = Convert.ToString(num);
                    return RedirectToAction("indianFiction", "products");
                }
                if (searching == "motivational" || searching == "Motivational")
                {
                    num = 304;
                    searching = Convert.ToString(num);
                    return RedirectToAction("motivationalBook", "products");
                }
                if (searching == "nonfictional" || searching == "non-fictional" || searching == "NonFictional" || searching == "Nonfictional" || searching == "Non-fictional" || searching == "non-Fictional" || searching == "nonFictional")
                {
                    num = 305;
                    searching = Convert.ToString(num);
                    return RedirectToAction("nonFiction", "products");
                }

                return View(db.productDescriptions.Where(x => x.productName.Contains(searching) || searching == null).ToList());





               
        }
        #endregion


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}
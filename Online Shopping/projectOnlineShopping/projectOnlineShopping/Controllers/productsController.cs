using projectOnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectOnlineShopping.Controllers
{
    [HandleError]
    public class productsController : Controller
    {
        private onlineShoppingEntities db = new onlineShoppingEntities();

        int nowId;


        #region List of Products in One category
        /// <summary>
        /// List of Each Product in one category,along with it's Description and Filters based on color,size and brand
        /// </summary>
        /// <param name="submit"></param>
        /// <returns>List of Products</returns>
        public ActionResult shirts(string submit)
        {
            if(submit == "red")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "orange")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());

            }
            if (submit == "blue")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "black")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "green")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "white")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "brown")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());

            }
            if (submit == "sandal")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }















            if (submit == "blackBerries")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "parkAvenue")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "ralphLauren")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "peterEngland")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "otto")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }










            if (submit == "s")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }
            if (submit == "xs")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());

            }
            if (submit == "l")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }
            if (submit == "xl")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }
            if (submit == "m")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }






            if (submit == "below 999")
            {
                int len = submit.Length;
                int l = len - 6;
                return View(db.productDescriptions.Where(x => x.currentCost.ToString().Length.Equals(l)).ToList());
            }
            if (submit == "above 999")
            {
                int len = submit.Length;
                int l = len - 5;
                return View(db.productDescriptions.Where(x => x.currentCost.ToString().Length.Equals(l)).ToList());
            }



            return View(db.productDescriptions.ToList());
        }
        public ActionResult kidsWear(string submit)
        {
            if (submit == "red")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "blue")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "black")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "green")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "white")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "skyBlue")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "yellow")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "pink")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "ash")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }










            if (submit == "zara")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "CHEROKEE")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "limited too")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "BONPOINT")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "PETIT BATEAU")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "justice")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "adidas")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "SKIP HOP.")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "ruff.")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "chicco.")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }








            if (submit == "s")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }
            if (submit == "m")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }


            if (submit == "below 999")
            {
                int len = submit.Length;
                int l = len - 6;
                return View(db.productDescriptions.Where(x => x.currentCost.ToString().Length.Equals(l)).ToList());
            }
            if (submit == "above 999")
            {
                int len = submit.Length;
                int l = len - 5;
                return View(db.productDescriptions.Where(x => x.currentCost.ToString().Length.Equals(l)).ToList());
            }


            
            return View(db.productDescriptions.ToList());

        }
        public ActionResult kurthis(string submit)
        {






            if (submit == "red")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "orange")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());

            }
            if (submit == "blue")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "black")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "green")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "white")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "brown")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());

            }
            if (submit == "sandal")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "yellow")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "pink")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "grey")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }



            if (submit == "Fabindia")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "Aurelia")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "globalDesi")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "Biba")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "Libas")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "Rangmanch")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "Soch")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "edivin")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }




            if (submit == "s")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }
            if (submit == "xs")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());

            }
            if (submit == "l")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }
            if (submit == "xl")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }
            if (submit == "m")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }






            if (submit == "below 999")
            {
                int len = submit.Length;
                int l = len - 6;
                return View(db.productDescriptions.Where(x => x.currentCost.ToString().Length.Equals(l)).ToList());
            }
            if (submit == "above 999")
            {
                int len = submit.Length;
                int l = len - 5;
                return View(db.productDescriptions.Where(x => x.currentCost.ToString().Length.Equals(l)).ToList());
            }
            return View(db.productDescriptions.ToList());

        }
        public ActionResult pants(string submit)
        {






            if (submit == "darkblue")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            
            if (submit == "blue")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "black")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
           
            if (submit == "white")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "brown")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());

            }
            if (submit == "sandal")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            
            if (submit == "grey")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }



            if (submit == "Everlane")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "Crew")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
           



            if (submit == "30W x 29L")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }
            if (submit == "32W x 29L")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());

            }
            if (submit == "33W x 29L")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }
            if (submit == "34W x 29L")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }
           






            if (submit == "below 999")
            {
                int len = submit.Length;
                int l = len - 6;
                return View(db.productDescriptions.Where(x => x.currentCost.ToString().Length.Equals(l)).ToList());
            }
            if (submit == "above 999")
            {
                int len = submit.Length;
                int l = len - 5;
                return View(db.productDescriptions.Where(x => x.currentCost.ToString().Length.Equals(l)).ToList());
            }



            return View(db.productDescriptions.ToList());
        }
        public ActionResult sarees(string submit)
        {





            if (submit == "red")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "orange")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());

            }
            if (submit == "blue")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "black")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "green")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
          
            if (submit == "sandal")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "yellow")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "pink")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "violet")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }



            if (submit == "Gaurang")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "kalamandir")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "Mysore Silk")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "Tussar Silk")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }



            if (submit == "below 999")
            {
                int len = submit.Length;
                int l = len - 6;
                return View(db.productDescriptions.Where(x => x.currentCost.ToString().Length.Equals(l)).ToList());
            }
            if (submit == "above 999")
            {
                int len = submit.Length;
                int l = len - 5;
                return View(db.productDescriptions.Where(x => x.currentCost.ToString().Length.Equals(l)).ToList());
            }





            return View(db.productDescriptions.ToList());
        }
        public ActionResult kidsBook()
        {
            return View(db.productDescriptions.ToList());
        }
        public ActionResult fantacyFiction()
        {

            return View(db.productDescriptions.ToList());
        }
        public ActionResult indianFiction()
        {
           
            return View(db.productDescriptions.ToList());
        }
        public ActionResult nonFiction()
        {
           
            return View(db.productDescriptions.ToList());
        }
        public ActionResult motivationalBook()
        {  
            return View(db.productDescriptions.ToList());
        }
        public ActionResult tv(string submit)
        {

            if (submit == "LG")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "HOM")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "Kodak")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "Panasonic")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "Mi")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "Samsung")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "Sansui")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }


            if (submit == "32 inches")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }
            if (submit == "40 inches")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }



















            return View(db.productDescriptions.ToList());
        }
        public ActionResult washingMchine(string submit)
        {




            if (submit == "red")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "white")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());

            }
           
            if (submit == "black")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "ash")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }



            if (submit == "Godrej")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "IFB")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "LG")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "MarQ")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "Onida")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "Samsung")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "Whirlpool")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }


            if (submit == "6.2kg")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }
            if (submit == "6.5kg")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }
            if (submit == "7kg")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }






            return View(db.productDescriptions.ToList());
        }
        public ActionResult mobilePhone(string submit)
        {

            if (submit == "red")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "golden")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());

            }

            if (submit == "black")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "ash")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "pink")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "blue")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "yellow")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "green")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "silver")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }


            if (submit == "Apple iPhone")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "Micromax")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "Nokia")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "OPPO")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "POCO")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "Realme 5")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "Redmi")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "Vivo")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }

            if (submit == "62GB")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }
            if (submit == "32GB")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }








            return View(db.productDescriptions.ToList());
        }
        public ActionResult microwaveOven(string submit)
        {

            if (submit == "black")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "white")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());

            }
            if (submit == "silver")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }




            if (submit == "MarQ")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "Samsung")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "IFB")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "lg")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }




            if (submit == "17L")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }
            if (submit == "28L")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }
            if (submit == "32L")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }
            if (submit == "30L")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }






            return View(db.productDescriptions.ToList());
        }
        public ActionResult laptop(string submit)
        {
            if (submit == "black")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
            if (submit == "blue")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());

            }
            if (submit == "silver")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }
          
            if (submit == "red")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());

            }
            if (submit == "gold")
            {
                return View(db.productDescriptions.Where(x => x.color.Contains(submit)).ToList());
            }





            if (submit == "asus")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "lenovo")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "dell")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "acer")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "apple")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }
            if (submit == "hp")
            {
                return View(db.productDescriptions.Where(x => x.brand.Contains(submit)).ToList());
            }







            if (submit == "13.3inch")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }
            if (submit == "14inch")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }
            if (submit == "15.6inch")
            {
                return View(db.productDescriptions.Where(x => x.size.Equals(submit)).ToList());
            }


            return View(db.productDescriptions.ToList());
        }
        #endregion



        #region Description of Product
        /// <summary>
        /// Detailed description of a particular product along with rating,size,images,price etc.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="catId"></param>
        /// <returns>Detailed description</returns>
        public ActionResult productDescription(int? id,int catId)
        {
            Session["CatogId"] = catId;
            Session["currId"] = id;
            productDescription productDescription = db.productDescriptions.Find(id);
            if (productDescription == null)
            {
                return HttpNotFound();
            }
            return View(productDescription);

           
        }
        #endregion



        #region Comparision of Products
        /// <summary>
        /// Comaprision of a particular product with other two similar products
        /// </summary>
        /// <returns>List of Products</returns>
        public ActionResult compare()
        {
           

            nowId =(int) Session["currId"];
            var plus = nowId + 1;
            ViewBag.catIdplus = plus;

            var minus = nowId - 1;
            ViewBag.catIdminus = minus;
            return View(db.productDescriptions.ToList());
        }
        #endregion



        #region Order Placed successfully
        /// <summary>
        /// Shows successfull message when User places order
        /// </summary>
        /// <returns>Placement of order</returns>
        public ActionResult successful()
        {
            Response.Write("<script>alert('Order Successfully PLaced');</script>");
            return View();
        }
        #endregion



        

    }
}
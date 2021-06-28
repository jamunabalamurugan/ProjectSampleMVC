using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationQuestionnare.Models;
using System.Threading.Tasks;
using System.Timers;
using System.Web.UI.WebControls;

namespace RegistrationQuestionnare.Controllers
{
    [HandleError]
    public class GTBController : Controller
    {
        ImageDBEntities db = new ImageDBEntities();


        // GET: GTB
        [NoDirectAccess]
        public ActionResult StartGame()
        {
            try
            {
                return View();
            }
            catch (ArgumentException ae)
            {
                ViewBag.exception = "Argument Exception Occured";
                return View();
            }
            catch (NullReferenceException ne)
            {
                ViewBag.exception = "Null Reference Exception Occured";
                return View();
            }
            catch (IndexOutOfRangeException ie)
            {
                ViewBag.exception = "Index Out Of Range Exception Occured";
                return View();
            }
            catch (Exception e)
            {
                ViewBag.exception = "Exception Occured";
                return View();
            }
        }

        //List<int> QuestionNumDisplayed = new List<int>();


        [NoDirectAccess]
        [HttpGet]
        public ActionResult LogoDisplay()
        {
            try
            {
                if (Session["QuestionNumDisplayed"] == null)
                {
                    List<int> QuestionNumDisplayed1 = new List<int>();
                    Session["QuestionNumDisplayed"] = QuestionNumDisplayed1 as List<int>;
                }
                List<int> QuestionNumDisplayed = (List<int>)Session["QuestionNumDisplayed"];

                RandomQuestion:
                var random = new Random();
                int num = random.Next(1, 20);
                int[] numarray = new int[10];

                if (!QuestionNumDisplayed.Contains(num))
                {
                    QuestionNumDisplayed.Add(num);
                    Session["QuestionNumDisplayed"] = QuestionNumDisplayed as List<int>;


                    var imageRecord = (from imagedata in db.ImageSets
                                       where imagedata.ImageID == num
                                       select imagedata);

                    string image = "";
                    string option1 = "";
                    string option2 = "";
                    string option3 = "";
                    string correctAns = "";

                    foreach (var imagefields in imageRecord)
                    {
                        image = imagefields.ImagePath;
                        option1 = imagefields.vOption1;
                        option2 = imagefields.vOption2;
                        option3 = imagefields.vOption3;
                        correctAns = imagefields.vCorrectOption;
                    }
                    ViewBag.image = image;
                    ViewBag.option1 = option1;
                    ViewBag.option2 = option2;
                    ViewBag.option3 = option3;
                    Session["corectAns"] = correctAns;
                    if (Session["points"] == null)
                    {
                        Session["points"] = 0;
                    }

                    //if (Session["LogoNo"] == null)
                    //{
                    //    Session["LogoNo"] = 1;
                    //}

                    if (Session["counter"] == null)
                    {
                        Session["counter"] = "0";
                    }
                }
                else
                {
                    goto RandomQuestion;
                }
                return View();

            }
            catch (ArgumentException ae)
            {
                ViewBag.exception = "Argument Exception Occured";
                return View();
            }
            catch (NullReferenceException ne)
            {
                ViewBag.exception = "Null Reference Exception Occured";
                return View();
            }
            catch (IndexOutOfRangeException ie)
            {
                ViewBag.exception = "Index Out Of Range Exception Occured";
                return View();
            }
            catch (Exception e)
            {
                ViewBag.exception = "Exception Occured";
                return View();
            }
        }

        [HttpPost]
        public ActionResult LogoDisplay(FormCollection form)
        {
            try
            {
                int present = int.Parse(Convert.ToString(Session["counter"]));
                present++;
                //int LogoCount = 1;
                //Session["LogoNo"] = Convert.ToString(LogoCount);
                //LogoCount++;
                Session["counter"] = Convert.ToString(present);
                string selectedOption = null;

                try
                {
                    selectedOption = form["Options"].ToString();
                }
                catch (Exception e)
                {
                    ViewBag.message1 = "Please select a choice" + e.Message;
                    return RedirectToAction("LogoDisplay");
                }

                int flag = 0;
                if (selectedOption == Session["corectAns"].ToString())
                {
                    Session["points"] = Convert.ToInt32(Session["points"]) + 5;
                    flag = 1;
                }

                else
                {
                    flag = 2;

                }
                if (present > 10)
                {

                    return RedirectToAction("ExitGame");
                }

                if (flag == 1)
                {
                    return RedirectToAction("Correct");
                }
                else
                {
                    return RedirectToAction("Wrong");
                }

            }
            catch (ArgumentException ae)
            {
                ViewBag.exception = "Argument Exception Occured";
                return View();
            }
            catch (NullReferenceException ne)
            {
                ViewBag.exception = "Null Reference Exception Occured";
                return View();
            }
            catch (IndexOutOfRangeException ie)
            {
                ViewBag.exception = "Index Out Of Range Exception Occured";
                return View();
            }
            catch (Exception e)
            {
                ViewBag.exception = "Exception Occured";
                return View();
            }
        }
        [NoDirectAccess]
        [HttpGet]
        public ActionResult ExitGame()
        {
            try
            {
                Session["activityflag"] = 1;
                return View();
            }
            catch (ArgumentException ae)
            {
                ViewBag.exception = "Argument Exception Occured";
                return View();
            }
            catch (NullReferenceException ne)
            {
                ViewBag.exception = "Null Reference Exception Occured";
                return View();
            }
            catch (IndexOutOfRangeException ie)
            {
                ViewBag.exception = "Index Out Of Range Exception Occured";
                return View();
            }
            catch (Exception e)
            {
                ViewBag.exception = "Exception Occured";
                return View();
            }
            
        }


        [NoDirectAccess]
        [HttpGet]
        public ActionResult Wrong()
        {
            try
            {
                return View();
            }
            catch (ArgumentException ae)
            {
                ViewBag.exception = "Argument Exception Occured";
                return View();
            }
            catch (NullReferenceException ne)
            {
                ViewBag.exception = "Null Reference Exception Occured";
                return View();
            }
            catch (IndexOutOfRangeException ie)
            {
                ViewBag.exception = "Index Out Of Range Exception Occured";
                return View();
            }
            catch (Exception e)
            {
                ViewBag.exception = "Exception Occured";
                return View();
            }

        }
        [HttpGet]
        [NoDirectAccess]
        public ActionResult Correct()
        {
            try
            {
                return View();
            }
            catch (ArgumentException ae)
            {
                ViewBag.exception = "Argument Exception Occured";
                return View();
            }
            catch (NullReferenceException ne)
            {
                ViewBag.exception = "Null Reference Exception Occured";
                return View();
            }
            catch (IndexOutOfRangeException ie)
            {
                ViewBag.exception = "Index Out Of Range Exception Occured";
                return View();
            }
            catch (Exception e)
            {
                ViewBag.exception = "Exception Occured";
                return View();
            }
        }
    }
}
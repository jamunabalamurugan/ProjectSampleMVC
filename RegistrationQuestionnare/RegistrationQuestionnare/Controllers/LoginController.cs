using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;
using CaptchaMvc.Models;
using RegistrationQuestionnare.Models;

namespace RegistrationQuestionnare.Controllers
{
    [HandleError]
    public class LoginController : Controller
    {
        /// <summary>
        /// This function decrypts the Encoded Data(here: User Password).
        /// It accepts and returns 1 parameter.
        /// The input parameter is the Encoded Data in String Format.
        /// The output parameter is the Decoded Data in String Format.
        ///  </summary>
        public static string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }

        // GET: Log
        #region Login Page - PS Number, Password, Captcha Validation
        /// <summary>
        /// In this Action Method, Login Deatils of User: PaySheet Number, Password and Captcha Validation is implemented.
        /// If login details are correctly inserted the Login is successful and the User is re-directed to next page,
        /// else, in-correct details are prompted.
        /// </summary>
        [NoDirectAccess]
        public ActionResult Page1()
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
        [HttpPost]
        public ActionResult Page1(FormCollection form, string password)
        {
            try
            {
                string psno = form["PSNo"];
                Session["psno"] = psno;

                using (var dbcontext = new IRelaxEntities4())
                {
                    var ps_exists = from temprec in dbcontext.EmployeePersonalDetails
                                    where temprec.vEmpID.Equals(psno)
                                    select temprec;


                    if (ps_exists.Count() != 0)

                    {
                        var pass_exists = from temprec in dbcontext.EmployeePersonalDetails
                                          where !temprec.vPassword.Equals(null) && temprec.vEmpID.Equals(psno)
                                          select temprec;

                        if (pass_exists.Count() > 0)
                        {
                            var encodedData = from enc_pass in dbcontext.EmployeePersonalDetails
                                              where enc_pass.vEmpID.Equals(psno)
                                              select new { ps = enc_pass.vPassword };
                            Session["enc_pass"] = "";
                            foreach (var ec in encodedData)
                            {
                                Session["enc_pass"] = ec.ps.ToString();
                            }
                            string decoded_pass = DecodeFrom64(Session["enc_pass"].ToString());
                            if (decoded_pass != password)
                            {
                                ViewBag.errorP = "Incorrect Password";
                                //Response.Write("Incorrect Password");
                                return View();
                            }
                        }
                        else
                        {
                            ViewBag.errorR = "User Not Found. Please Register";
                            //Response.Write("Please Register");
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.errorL = "Invalid PS No.";
                        //Response.Write("Invalid PS No.");
                        return View();
                    }

                    if (!this.IsCaptchaValid("Validate your captcha"))
                    {
                        ViewBag.ErrorMessage = "Invalid Captcha";
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Page2");
                    }

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
        #endregion


        #region Daily Mood Record
        /// <summary>
        /// After successful Login, the Daily(Current) mood record is taken from the user with help of Emoji Reactions.
        /// On selecting a particular mood, the user is re-directed to Dashboard.
        /// </summary>
        [NoDirectAccess]
        public ActionResult Page2()
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
        #endregion


        //public ActionResult Page3(int id)
        //{
        //    ViewBag.msg = id;
        //    Response.Write(id);

        //    IRelaxEntities3 db = new IRelaxEntities3();

        //    db.insert_login_time(Convert.ToString(Session["psno"]), id);
        //    return View();
        //}
    }
}

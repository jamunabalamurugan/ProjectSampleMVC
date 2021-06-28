using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationQuestionnare.Models;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Text;

namespace RegistrationQuestionnare.Controllers
{
    [HandleError]
    public class RegisterController : Controller
    {
        #region Encode Password
        /// <summary>
        /// This function encrypts the Encoded Data(here: User Password).
        /// The input parameter is the Input Data in String Format.
        /// The output parameter is the Encoded Data in String Format.
        /// </summary>
        /// <param name="password"></param>

        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        #endregion
        #region Decode Password

        /// <summary>
        /// This function decrypts the Encoded Data(here: User Password).
        /// The input parameter is the Encoded Data in String Format.
        /// The output parameter is the Decoded Data in String Format.
        ///  </summary>
        ///  <param name="encodedData"></param>

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
        #endregion
        #region OTP Function
        /// <summary>
        /// This method generates a random OTP. This OTP length is provided as 6.
        /// The OTP is a random combination of digits between 0-9.
        /// </summary>
        /// <param name="iOTPLength"></param>
        /// <param name="saAllowedCharacters"></param>
        /// <returns>This method returns the generated OTP.</returns>

        public static string GenerateRandomOTP(int iOTPLength, string[] saAllowedCharacters)
        {
            string sOTP = String.Empty;
            string sTempChars = String.Empty;
            Random rand = new Random();

            for (int i = 0; i < iOTPLength; i++)

            {

                int p = rand.Next(0, saAllowedCharacters.Length);
                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];
                sOTP += sTempChars;

            }

            return sOTP;

        }
        #endregion
        #region Stress Calucation
        /// <summary>
        /// This method computes the stress value based on the inputs received via Questions asked to the User and the 
        /// Daily(Current) mood of the User.
        /// </summary>
        /// <param name="baseValue">This is the stress value based on the 10 Questions and it's responses</param>
        /// <param name="presentValue">This is the numerical equivalent of the User's Current Mood(Emoji Interpretation)  </param>
        /// <param name="length">The length paramter is number of questions as to the User.</param>
        /// <returns>Stress value of the first time User(Registration).</returns>
        public static double CalculateStress(double baseValue, double presentValue, double length)
        {
            double stress = ((length * baseValue) + presentValue) / (length + 1);
            return stress;
        }
        #endregion
        IRelaxEntities4 db = new IRelaxEntities4();
//---------------------------------------------------------------------------------------------------------------------
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        //---------------------------------------------------------------------------------------------------------------------
        #region Random Question 
        /// <summary>
        /// This Action Method generates 10 Random Questions for calculating stress. 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [NoDirectAccess]
        public ActionResult Question()
        {
            try
            {
                Random random = new Random();
                int qid = random.Next(1, 15);

                var questions = from ques in db.Questionaires
                                where ques.iQuestionID == qid
                                select ques;
                string qq = "";
                foreach (var question in questions)
                {
                    qq = question.vQuestionDesc;
                }

                ViewBag.question = qq;

                Session["counter"] = "0";
                List<int> answers = new List<int>();
                Session["answers"] = answers;
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
        public ActionResult Question(FormCollection form)
        {
            try
            {
                int present = int.Parse(Convert.ToString(Session["counter"]));
                List<int> answers = (List<int>)Session["answers"];
                int answer;
                if (form["Answer"] == null)
                {
                    answer = 3;
                }
                else
                {
                    answer = Convert.ToInt32(form["Answer"]);
                }
                if (present % 2 != 0)//Positive Answer
                {
                    switch (answer)
                    {
                        case 1: answer = 5; break;
                        case 2: answer = 4; break;
                        case 4: answer = 2; break;
                        case 5: answer = 1; break;
                    }

                }
                answers.Add(answer);
                Session["answers"] = answers;
                present++;
                Session["counter"] = Convert.ToString(present);
                if (present >= 10)
                {
                    List<int> finalanswers = (List<int>)Session["answers"];
                    double avg = finalanswers.Average();
                    Session["average"] = avg;
                    return RedirectToAction("Preference");
                }
                else
                {
                    //Positive Questions
                    if (present % 2 == 0)
                    {
                        Random random = new Random();
                        int qid = random.Next(16, 30);

                        var questions = from ques in db.Questionaires
                                        where ques.iQuestionID == qid
                                        select ques;
                        string qq = "";
                        foreach (var question in questions)
                        {
                            qq = question.vQuestionDesc;
                        }

                        ViewBag.question = qq;
                    }
                    else//Negative Questions
                    {
                        Random random = new Random();
                        int qid = random.Next(1, 15);

                        var questions = from ques in db.Questionaires
                                        where ques.iQuestionID == qid
                                        select ques;
                        string qq = "";
                        foreach (var question in questions)
                        {
                            qq = question.vQuestionDesc;
                        }

                        ViewBag.question = qq;
                    }

                    return View();

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
        //---------------------------------------------------------------------------------------------------------------------
        #region Weekend Activity Preference
        /// <summary>
        /// This ActionMethod Retrives the list of weekend activities from Database.
        /// In the Post Method, the selected Weekend Activity record is added with respect to the particular User in the Post Method. 
        /// </summary>
        /// <returns>Redirects to Daily(Current) Mood Record Page.</returns>
        [HttpGet]
        [NoDirectAccess]
        public ActionResult Preference()
        {
            try
            {
                var activities = from act in db.WeekendActivities select act;
                ViewBag.activities = activities;
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
        public ActionResult Preference(FormCollection form)
        {
            try
            {
                WeekendEmployeeInterest w = new WeekendEmployeeInterest();
                for (int i = 1; i < 9; i++)
                {
                    //w.vEmpID =Convert.ToString(Session["psno"]);
                    if (form[Convert.ToString(i)] == "on")
                    {
                        w.vEmpID = Convert.ToString(Session["psno"]);
                        w.iWActivityID = i;
                        db.WeekendEmployeeInterests.Add(w);
                        db.SaveChanges();
                    }
                }
                var activities = from act in db.WeekendActivities select act;
                ViewBag.activities = activities;
                return RedirectToAction("Mood");

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
        //---------------------------------------------------------------------------------------------------------------------
        #region PS Number (Registration Page-1)
        /// <summary>
        /// This Method accepts the user's PS Number. 
        /// This is stored in the session variable(psno)
        /// </summary>
        /// <returns>Redirects to Display User Information Page</returns>
        [HttpGet]
        [NoDirectAccess]
        public ActionResult Form1()
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
        [HandleError]
        [HttpPost]
        public ActionResult Form1(FormCollection form)
        {
            try
            {
                string psno = form["PSNo"];
                Session["psno"] = psno;

                var ps_exists = from temprec in db.EmployeePersonalDetails
                                where temprec.vEmpID.Equals(psno)
                                select temprec;

                if (ps_exists.Count() != 0)
                {

                    var pass_exists = from temprec in db.EmployeePersonalDetails
                                      where !temprec.vPassword.Equals(null) && temprec.vEmpID.Equals(psno)
                                      select temprec;
                    if (pass_exists.Count() != 0)
                    {
                        ViewBag.errorQ = "User already registered. Kindly Login to continue.";
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Form2");
                    }
                }
                else

                {
                    ViewBag.errorQ = "Invalid PS Number";
                    return View();
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
            //Response.Write(psno);
            //Response.Write(ViewBag.name);
            //return View();

        }
        #endregion
        //---------------------------------------------------------------------------------------------------------------------
        #region User Information
        /// <summary>
        /// This ActionMethod retrives the user details from the database. 
        /// The session variable (psno) is used.
        /// </summary>
        /// <returns>Redirects to OTP Verification Page</returns>
        [HttpGet]
        [NoDirectAccess]
        public ActionResult Form2()
        {
            try
            {
                string psno = Convert.ToString(Session["psno"]);
                var employeeDetails = from emp in db.EmployeePersonalDetails
                                      where emp.vEmpID == psno
                                      select emp;

                foreach (var employee in employeeDetails)
                {
                    ViewBag.name = employee.vEmpName;
                    ViewBag.domain = employee.vWorkDomain;
                    ViewBag.location = employee.vWorkingLocation;
                    ViewBag.age = employee.iEmpAge;
                    ViewBag.mobile = employee.vEmpMobile;
                    ViewBag.mail = employee.vEmpMail;
                    ViewBag.gender = employee.vEmpGender;
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
        public ActionResult Form2(FormCollection form)
        {
            try
            {
                return RedirectToAction("Form3");
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
        //---------------------------------------------------------------------------------------------------------------------
        #region OTP
        /// <summary>
        /// Here, OTP is generated using 'GenerateRandomOTP(,)' function call.
        /// The OTP is sent to the rgistered and verified E-mail ID of the User.
        /// In the Post action, the User Enterd OTP and System Generated OTP are verified.
        /// </summary>
        /// <returns>If OTP is not verified same page is returned. On successful OTP Verification Redirects to Set Password Page.</returns>
        [HttpGet]
        [NoDirectAccess]
        public ActionResult Form3()
        {
            try
            {
                //OTP and EMail Logic
                string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                //otp gen1 = new otp();
                string sRandomOTP = GenerateRandomOTP(6, saAllowedCharacters);
                //Console.WriteLine("OTP:" + sRandomOTP);
                //Console.ReadKey();

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("rudram.c.bhimpure@gmail.com");
                //Email retrieval from Database based on PS no.
                string psno = Convert.ToString(Session["psno"]);
                var employeeDetails = from emp in db.EmployeePersonalDetails
                                      where emp.vEmpID == psno
                                      select emp;
                string email = "";
                string name = "";
                foreach (var employee in employeeDetails)
                {
                    name = employee.vEmpName;
                    email = employee.vEmpMail;
                }

                mail.To.Add(email);
                mail.Subject = "iRelax OTP verification";
                mail.Body = "Dear " + name + ", \nYour One Time Password for Registration is \n" + sRandomOTP + "\n\nRegards,\nTeam iRelax";
                Session["sotp"] = sRandomOTP;
                //System.Net.Mail.Attachment attachment;
                //attachment = new System.Net.Mail.Attachment("captain.jpg");
                //mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("irelaxapp@gmail.com", "irelax1234");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
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
        public ActionResult Form3(FormCollection form)
        {
            try
            {
                string otp = form["otp"];
                string sotp = Convert.ToString(Session["sotp"]);

                if (otp == sotp)
                {
                    return RedirectToAction("Form4");
                }
                else
                {
                    ViewBag.message = "Incorrect OTP. Please Enter Valid OTP.";
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
        #endregion
        //---------------------------------------------------------------------------------------------------------------------
        #region Password
        /// <summary>
        /// The User has to set a password for his Account. 
        /// The user has to re-enter the password for verification.
        /// If the passwords match, the password is encrypted and sent to the database.
        /// If passowords, don't match, User has to re-enter the password.
        /// </summary>
        /// <returns>On Successful password setting, Redirects to the Question's page</returns>
        [HttpGet]
        [NoDirectAccess]
        public ActionResult Form4()
        {
            try
            {
                ViewBag.message = "Your OTP has been verified successfully.";

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
        public ActionResult Form4(FormCollection form)
        {
            try
            {
                string password = form["password"];
                string rpassword = form["rpassword"];
                if (password == "")
                {
                    ViewBag.message = "Please Enter Password";
                    return View();
                }
                if (rpassword == "")
                {
                    ViewBag.message = "Please Re-Enter Password";
                    return View();
                }
                if (password != rpassword)
                {
                    ViewBag.message = "Passwords do not match";
                }
                else
                {
                    string psno = Convert.ToString(Session["psno"]);
                    //var employee = from emp in db.EmployeePersonalDetails
                    //                                  where emp.vEmpID == psno
                    //                                  select emp.vPassword;
                    //employee.vPassword=

                    string encodedData = EncodePasswordToBase64(password);


                    EmployeePersonalDetail employee = db.EmployeePersonalDetails.Where(x => x.vEmpID == psno).FirstOrDefault();
                    employee.vPassword = encodedData;
                    db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Message");
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
        #endregion
        //---------------------------------------------------------------------------------------------------------------------
        #region Mood
        /// <summary>
        /// The Daily (current) mood is recorded from Emoji Reaction.
        /// Also, the CalculateStress(,,)function call calculates Stress level of the User.
        /// The current mood and stress value stress value is recorded in the database.
        /// </summary>
        /// <returns>Redirets to the Dashboard</returns>
        [HttpGet]
        [NoDirectAccess]
        public ActionResult Mood()
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
        public ActionResult Mood(FormCollection form)
        {
            try
            {
                //Session["psno"] = "10662455";
                double id = Convert.ToInt32(Session["mood"]);
                double stress = CalculateStress(Convert.ToDouble(Session["average"]), id, 10.0);
                DailyLoginTime dlt = new DailyLoginTime();
                dlt.iMood = Convert.ToInt32(id);
                dlt.dbStressValue = stress;
                dlt.vEmpID = Convert.ToString(Session["psno"]);
                dlt.dLoginTime = DateTime.Now;
                if (ModelState.IsValid)
                {
                    db.DailyLoginTimes.Add(dlt);
                    db.SaveChanges();

                    //return View();
                    //return RedirectToAction("");
                    return RedirectToAction("Dashboard", "Main");
                }
                else
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
        //---------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        [NoDirectAccess]
        public ActionResult Dash()
        {
            try
            {
                Response.Write(Session["mood"]);
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
        public ActionResult Emoji(int id=3)
        {
            try
            {
                System.Threading.Thread.Sleep(1000);
                Session["mood"] = id;
                return RedirectToAction("Mood");
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

        public ActionResult Message()
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
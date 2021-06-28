//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace PhotoUploadNew.Controllers
//{
//    public class MySpaceController : Controller
//    {
//        // GET: MySpace
//        public ActionResult Index()
//        {
//            return View();
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationQuestionnare.Models;
using System.IO;
using System.Data.Entity;
using System.Net;

namespace RegistrationQuestionnare.Controllers
{
    [HandleError]
    public class MySpaceController : Controller
    {
        IRelaxEntities4 db = new IRelaxEntities4();

        // GET: Photo
        [NoDirectAccess]
        public ActionResult Index()
        {
            return View(db.EmployeePersonalDetails.ToList());
        }
        [NoDirectAccess]
        public ActionResult Details()
        {
            try
            {
                string id = "10662479";
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var employeePersonalDetail = db.EmployeePersonalDetails.FirstOrDefault(pd=>pd.vEmpID==id);
                //var employeePersonalDetail = db.EmployeePersonalDetails.Find(id);

                if (employeePersonalDetail == null)
                {
                    return HttpNotFound();
                }
                return View(employeePersonalDetail);
            }
            catch(Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
            //EmployeePersonalDetail obj = db.EmployeePersonalDetails.Find(id);
            //return View(obj);
           
        }

        [HttpGet]
        [NoDirectAccess]
        public ActionResult Update(string id)
        {
            EmployeePersonalDetail emp = db.EmployeePersonalDetails.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (emp == null)
            {
                return HttpNotFound();
            }

            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "vEmpID,vEmpName,vWorkDomain,vWorkingLocation,vEmpMobile,vEmpMail,vEmpGender,dBirthDate,iCreditPoints")] EmployeePersonalDetail emp, HttpPostedFileBase ImageUpload, EmployeePersonalDetail empProfile)
        {
            empProfile = db.EmployeePersonalDetails.Where(x => x.vEmpID == "10662432").FirstOrDefault();
            try
            {
                if (ModelState.IsValid)
                {

                    string filename = Path.GetFileNameWithoutExtension(ImageUpload.FileName);
                    string extension = Path.GetExtension(ImageUpload.FileName);
                    if (extension == ".jpeg" || extension == ".jpg" || extension == ".png" || extension == ".bmp")
                    {
                        filename = filename + extension;
                        //Copy the file from client location to the Server Path /Images folder
                        string filename1 = Path.Combine(Server.MapPath("~/Images/"), filename);
                        ImageUpload.SaveAs(filename1);
                        //emp=db.EmployeePersonalDetails.Where(x => x.vEmpID == emp.vEmpID).FirstOrDefault();
                        filename = "~/Images/" + filename;
                        emp.ProfilePhoto = filename;
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        ViewBag.Error = "Only .JPG,.JPEG,.PNG files accepted.";
                        return View();
                    }
                }
            }
            catch (Exception)
            {

                //db.EmployeePersonalDetails.Where(x => x.vEmpID == emp.vEmpID).FirstOrDefault() select{ emp.ProfilePhoto};
                string filename = Convert.ToString(empProfile.ProfilePhoto);
                emp.ProfilePhoto = filename;
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            //catch(Exception e)
            //{
            //    return View();
            //}

            return RedirectToAction("Details");

        }
        
        public ActionResult Space()
        {
            string psno = Convert.ToString(Session["psno"]);
            return Redirect("http://localhost:50209/MySpace/Details/"+psno);
        }

        //public int abc()
        //{
        //    int index = 0;
        //    index = 1;
        //    Label:
        //    index += 1;
        //    int z = index;
        //    if (index < 3)
        //    {
        //        goto Label;
        //    }
        //    return z;
        //}


    }
}
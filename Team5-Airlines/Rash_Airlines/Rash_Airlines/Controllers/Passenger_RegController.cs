using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rash_Airlines.Models;

namespace Rash_Airlines.Controllers
{
    public class Passenger_RegController : Controller
    {
        private Rash_AirlinesEntities db = new Rash_AirlinesEntities();

        // GET: Passenger_Reg
        public ActionResult Index_Passenger()
        {
            return View(db.Passenger_Reg.ToList());
        }

        // GET: Passenger_Reg/Details/5
        public ActionResult Details_Passenger(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger_Reg passenger_Reg = db.Passenger_Reg.Find(id);
            if (passenger_Reg == null)
            {
                return HttpNotFound();
            }
            return View(passenger_Reg);
        }

        // GET: Passenger_Reg/Create
        public ActionResult Create_Passenger()
        {
            return View();
        }

        // POST: Passenger_Reg/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Passenger([Bind(Include = "passenger_id,title,first_name,last_name,email,pwd,confirm_pwd,dob,mobile")] Passenger_Reg passenger_Reg)
        {
            if (ModelState.IsValid)
            {
                db.Passenger_Reg.Add(passenger_Reg);
                db.SaveChanges();
                return RedirectToAction("Login_Passenger","Passenger_Login");
            }

            return View(passenger_Reg);
        }

        // GET: Passenger_Reg/Edit/5
        public ActionResult Edit_Passenger(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger_Reg passenger_Reg = db.Passenger_Reg.Find(id);
            if (passenger_Reg == null)
            {
                return HttpNotFound();
            }
            return View(passenger_Reg);
        }

        // POST: Passenger_Reg/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Passenger([Bind(Include = "passenger_id,title,first_name,last_name,email,pwd,confirm_pwd,dob,mobile")] Passenger_Reg passenger_Reg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(passenger_Reg).State = EntityState.Modified;
                db.SaveChanges();
                return View("Details_Passenger");
            }
            return View(passenger_Reg);
        }

        // GET: Passenger_Reg/Delete/5
        public ActionResult Delete_Passenger(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger_Reg passenger_Reg = db.Passenger_Reg.Find(id);
            if (passenger_Reg == null)
            {
                return HttpNotFound();
            }
            return View(passenger_Reg);
        }

        // POST: Passenger_Reg/Delete/5
        [HttpPost, ActionName("Delete_Passenger")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Passenger_Reg passenger_Reg = db.Passenger_Reg.Find(id);
            db.Passenger_Reg.Remove(passenger_Reg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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

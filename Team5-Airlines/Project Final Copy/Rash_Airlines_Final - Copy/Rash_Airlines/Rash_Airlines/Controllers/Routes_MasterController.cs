﻿using System;
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
    public class Routes_MasterController : Controller
    {
        private Rash_AirlinesEntities db = new Rash_AirlinesEntities();

        // GET: Routes_Master
        public ActionResult Index_Routes()
        {
            var routes_Master = db.Routes_Master.Include(r => r.Place).Include(r => r.Place1);
            return View(routes_Master.ToList());
        }

        // GET: Routes_Master/Details/5
        public ActionResult Details_Routes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routes_Master routes_Master = db.Routes_Master.Find(id);
            if (routes_Master == null)
            {
                return HttpNotFound();
            }
            return View(routes_Master);
        }

        // GET: Routes_Master/Create
        public ActionResult Create_Routes()
        {
            ViewBag.arrival = new SelectList(db.Places, "place_id", "place_name");
            ViewBag.departure = new SelectList(db.Places, "place_id", "place_name");
            return View();
        }

        // POST: Routes_Master/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Routes([Bind(Include = "route_id,departure,arrival,economy_cost,business_cost")] Routes_Master routes_Master)
        {
            if (ModelState.IsValid)
            {
                db.Routes_Master.Add(routes_Master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.arrival = new SelectList(db.Places, "place_id", "place_name", routes_Master.arrival);
            ViewBag.departure = new SelectList(db.Places, "place_id", "place_name", routes_Master.departure);
            return View(routes_Master);
        }

        // GET: Routes_Master/Edit/5
        public ActionResult Edit_Routes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routes_Master routes_Master = db.Routes_Master.Find(id);
            if (routes_Master == null)
            {
                return HttpNotFound();
            }
            ViewBag.arrival = new SelectList(db.Places, "place_id", "place_name", routes_Master.arrival);
            ViewBag.departure = new SelectList(db.Places, "place_id", "place_name", routes_Master.departure);
            return View(routes_Master);
        }

        // POST: Routes_Master/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Routes([Bind(Include = "route_id,departure,arrival,economy_cost,business_cost")] Routes_Master routes_Master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routes_Master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.arrival = new SelectList(db.Places, "place_id", "place_name", routes_Master.arrival);
            ViewBag.departure = new SelectList(db.Places, "place_id", "place_name", routes_Master.departure);
            return View(routes_Master);
        }

        // GET: Routes_Master/Delete/5
        public ActionResult Delete_Routes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routes_Master routes_Master = db.Routes_Master.Find(id);
            if (routes_Master == null)
            {
                return HttpNotFound();
            }
            return View(routes_Master);
        }

        // POST: Routes_Master/Delete/5
        [HttpPost, ActionName("Delete_Routes")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Routes_Master routes_Master = db.Routes_Master.Find(id);
            db.Routes_Master.Remove(routes_Master);
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

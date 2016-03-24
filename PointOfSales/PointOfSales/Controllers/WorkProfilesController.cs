using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PointOfSales.Models;
using Microsoft.AspNet.Identity;

namespace PointOfSales.Controllers
{
    public class WorkProfilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WorkProfiles
        public ActionResult Index()
        {
            return View(db.WorkProfiles.ToList());
        }

        // GET: WorkProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkProfile workProfile = db.WorkProfiles.Find(id);
            if (workProfile == null)
            {
                return HttpNotFound();
            }
            return View(workProfile);
        }

        // GET: WorkProfiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FullName,Email,PhoneNumber,Street,City,State,ZipCode")] WorkProfile workProfile)
        {
            workProfile.UserID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.WorkProfiles.Add(workProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workProfile);
        }

        // GET: WorkProfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkProfile workProfile = db.WorkProfiles.Find(id);
            if (workProfile == null)
            {
                return HttpNotFound();
            }
            return View(workProfile);
        }

        // POST: WorkProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FullName,Email,PhoneNumber,Street,City,State,ZipCode")] WorkProfile workProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workProfile);
        }

        // GET: WorkProfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkProfile workProfile = db.WorkProfiles.Find(id);
            if (workProfile == null)
            {
                return HttpNotFound();
            }
            return View(workProfile);
        }

        // POST: WorkProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkProfile workProfile = db.WorkProfiles.Find(id);
            db.WorkProfiles.Remove(workProfile);
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

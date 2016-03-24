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
    public class BillsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bills
        public ActionResult Index()
        {
            var bills = db.Bills.Include(b => b.Menu).Include(b => b.WorkProfile);
            return View(bills.ToList());
        }

        // GET: Bills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // GET: Bills/Create
        public ActionResult Create()
        {
            
             
            ViewBag.MenuID = new SelectList(db.Menus.OrderBy(x => x.Name), "ID", "Name");

            ViewBag.WorkProfileID = new SelectList(db.WorkProfiles.OrderBy(x => x.FullName), "ID", "FullName");
            return View();
        }

        // POST: Bills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TableNumber,MenuID,WorkProfileID")] Bill bill)
        {
            bill.UserID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.Bills.Add(bill);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.MenuID = new SelectList(db.Menus, "ID", "Name", bill.MenuID);
            ViewBag.WorkProfileID = new SelectList(db.WorkProfiles, "ID", "FullName", bill.WorkProfileID);
            return View(bill);
        }

        // GET: Bills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuID = new SelectList(db.Menus, "ID", "Name", bill.MenuID);
            ViewBag.WorkProfileID = new SelectList(db.WorkProfiles, "ID", "FullName", bill.WorkProfileID);
            return View(bill);
        }

        // POST: Bills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TableNumber,MenuID,WorkProfileID")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuID = new SelectList(db.Menus, "ID", "Name", bill.MenuID);
            ViewBag.WorkProfileID = new SelectList(db.WorkProfiles, "ID", "FullName", bill.WorkProfileID);
            return View(bill);
        }

        // GET: Bills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bill bill = db.Bills.Find(id);
            db.Bills.Remove(bill);
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

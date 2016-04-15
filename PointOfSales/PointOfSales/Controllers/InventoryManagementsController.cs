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
using System.Net.Mail;
using PointOfSales.Custom_Filters;

namespace PointOfSales.Controllers
{
    public class InventoryManagementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InventoryManagements
        [AuthLog(Roles = "02Management")]
        public ActionResult Index()
        {
            return View(db.InventoryManagements.ToList());
        }

        // GET: InventoryManagements/Details/5
        [AuthLog(Roles = "02Management")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryManagement inventoryManagement = db.InventoryManagements.Find(id);
            if (inventoryManagement == null)
            {
                return HttpNotFound();
            }
            return View(inventoryManagement);
        }

        // GET: InventoryManagements/Create
        [AuthLog(Roles = "02Management")]
        public ActionResult Create()
        {
            return View();
        }

        public void sendEmail()
        {
            //posterNose();
        
           var UserID = User.Identity.GetUserId();
            var UserInfo = db.WorkProfiles.Where(userid => userid.UserID == UserID);
            var Boss = db.WorkProfiles.Select(x => x).Where(y => y.UserID == UserID).FirstOrDefault();

            var message = new MailMessage("xxxdeathstarmlgxxx@gmail.com", "Nephithys@gmail.com");
            message.Subject = "Urgent";
            message.Body = "Some items in your inventory are runnin low!";
            SmtpClient mailer = new SmtpClient("smtp.gmail.com", 587);
            mailer.Credentials = new NetworkCredential("xxxdeathstarmlgxxx@gmail.com", "AAAFCAFCAEEEFCA#FCAFCA");
            mailer.EnableSsl = true;
            mailer.Send(message);
        }

        public void posterNose()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("SParty.wav");
            player.Play();

        }
        // POST: InventoryManagements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Quantity,Description")] InventoryManagement inventoryManagement)
        {
            if (ModelState.IsValid)
            {
                db.InventoryManagements.Add(inventoryManagement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventoryManagement);
        }

        // GET: InventoryManagements/Edit/5
        [AuthLog(Roles = "02Management")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryManagement inventoryManagement = db.InventoryManagements.Find(id);
            if (inventoryManagement == null)
            {
                return HttpNotFound();
            }
            return View(inventoryManagement);
        }

        // POST: InventoryManagements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Quantity,Description")] InventoryManagement inventoryManagement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventoryManagement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventoryManagement);
        }

        // GET: InventoryManagements/Delete/5
        [AuthLog(Roles = "02Management")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryManagement inventoryManagement = db.InventoryManagements.Find(id);
            if (inventoryManagement == null)
            {
                return HttpNotFound();
            }
            return View(inventoryManagement);
        }

        // POST: InventoryManagements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InventoryManagement inventoryManagement = db.InventoryManagements.Find(id);
            db.InventoryManagements.Remove(inventoryManagement);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DogWalking.Models;

namespace DogWalking.Controllers
{
    public class EmergencyContactController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EmergencyContact
        public ActionResult Index()
        {
            return View(db.EmergencyContactModels.ToList());
        }

        // GET: EmergencyContact/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmergencyContactModel emergencyContactModel = db.EmergencyContactModels.Find(id);
            if (emergencyContactModel == null)
            {
                return HttpNotFound();
            }
            return View(emergencyContactModel);
        }

        // GET: EmergencyContact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmergencyContact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,RelationshipToChild,HomePhoneNumber,CellPhoneNumber")] EmergencyContactModel emergencyContactModel)
        {
            if (ModelState.IsValid)
            {
                emergencyContactModel.EmergencyContactId = Guid.NewGuid();
                db.EmergencyContactModels.Add(emergencyContactModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emergencyContactModel);
        }

        // GET: EmergencyContact/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmergencyContactModel emergencyContactModel = db.EmergencyContactModels.Find(id);
            if (emergencyContactModel == null)
            {
                return HttpNotFound();
            }
            return View(emergencyContactModel);
        }

        // POST: EmergencyContact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,RelationshipToChild,HomePhoneNumber,CellPhoneNumber")] EmergencyContactModel emergencyContactModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emergencyContactModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emergencyContactModel);
        }

        // GET: EmergencyContact/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmergencyContactModel emergencyContactModel = db.EmergencyContactModels.Find(id);
            if (emergencyContactModel == null)
            {
                return HttpNotFound();
            }
            return View(emergencyContactModel);
        }

        // POST: EmergencyContact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            EmergencyContactModel emergencyContactModel = db.EmergencyContactModels.Find(id);
            db.EmergencyContactModels.Remove(emergencyContactModel);
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

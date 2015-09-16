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
    public class BakingClassController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BakingClass
        public ActionResult Index()
        {
            return View(db.BakingClassModels.ToList());
        }

        // GET: BakingClass/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BakingClassModel bakingClassModel = db.BakingClassModels.Find(id);
            if (bakingClassModel == null)
            {
                return HttpNotFound();
            }
            return View(bakingClassModel);
        }

        // GET: BakingClass/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BakingClass/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BakingClassId,ClassTime,MaxNumberOfAttendees,MinAge,MaxAge")] BakingClassModel bakingClassModel)
        {
            if (ModelState.IsValid)
            {
                bakingClassModel.BakingClassId = Guid.NewGuid();
                db.BakingClassModels.Add(bakingClassModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bakingClassModel);
        }

        // GET: BakingClass/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BakingClassModel bakingClassModel = db.BakingClassModels.Find(id);
            if (bakingClassModel == null)
            {
                return HttpNotFound();
            }
            return View(bakingClassModel);
        }

        // POST: BakingClass/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BakingClassId,ClassTime,MaxNumberOfAttendees,MinAge,MaxAge")] BakingClassModel bakingClassModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bakingClassModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bakingClassModel);
        }

        // GET: BakingClass/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BakingClassModel bakingClassModel = db.BakingClassModels.Find(id);
            if (bakingClassModel == null)
            {
                return HttpNotFound();
            }
            return View(bakingClassModel);
        }

        // POST: BakingClass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            BakingClassModel bakingClassModel = db.BakingClassModels.Find(id);
            db.BakingClassModels.Remove(bakingClassModel);
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

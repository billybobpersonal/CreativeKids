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
    public class ClassTermController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClassTerm
        public ActionResult Index()
        {
            return View(db.ClassTerms.ToList());
        }

        // GET: ClassTerm/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassTermModel classTerm = db.ClassTerms.Find(id);
            if (classTerm == null)
            {
                return HttpNotFound();
            }
            return View(classTerm);
        }

        // GET: ClassTerm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassTerm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassTermId,StartDate,EndDate")] ClassTermModel classTerm)
        {
            if (ModelState.IsValid)
            {
                classTerm.ClassTermId = Guid.NewGuid();
                db.ClassTerms.Add(classTerm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classTerm);
        }

        // GET: ClassTerm/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassTermModel classTerm = db.ClassTerms.Find(id);
            if (classTerm == null)
            {
                return HttpNotFound();
            }
            return View(classTerm);
        }

        // POST: ClassTerm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassTermId,StartDate,EndDate")] ClassTermModel classTerm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classTerm);
        }

        // GET: ClassTerm/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassTermModel classTerm = db.ClassTerms.Find(id);
            if (classTerm == null)
            {
                return HttpNotFound();
            }
            return View(classTerm);
        }

        // POST: ClassTerm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ClassTermModel classTerm = db.ClassTerms.Find(id);
            db.ClassTerms.Remove(classTerm);
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

using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DogWalking.Models;

namespace DogWalking.Controllers
{
    public class ParentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Parent
        public ActionResult Index()
        {
            return View(db.ParentModels.ToList());
        }

        // GET: Parent/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentModel parentModel = db.ParentModels.Find(id);
            if (parentModel == null)
            {
                return HttpNotFound();
            }
            return View(parentModel);
        }

        // GET: Parent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Sex,HomeContactNumber,CellphoneNumber,EmailAddress")] ParentModel parentModel)
        {
            if (ModelState.IsValid)
            {
                parentModel.ParentId = Guid.NewGuid();
                db.ParentModels.Add(parentModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parentModel);
        }

        // GET: Parent/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentModel parentModel = db.ParentModels.Find(id);
            if (parentModel == null)
            {
                return HttpNotFound();
            }
            return View(parentModel);
        }

        // POST: Parent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Sex,HomeContactNumber,CellphoneNumber,EmailAddress")] ParentModel parentModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parentModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parentModel);
        }

        // GET: Parent/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentModel parentModel = db.ParentModels.Find(id);
            if (parentModel == null)
            {
                return HttpNotFound();
            }
            return View(parentModel);
        }

        // POST: Parent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ParentModel parentModel = db.ParentModels.Find(id);
            db.ParentModels.Remove(parentModel);
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

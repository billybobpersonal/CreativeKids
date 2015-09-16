using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DogWalking.Models;

namespace DogWalking.Controllers
{
    public class ChildController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Child
        public ActionResult Index()
        {
            return View(db.ChildModels.ToList());
        }

        // GET: Child/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildModel childModel = db.ChildModels.Find(id);
            if (childModel == null)
            {
                return HttpNotFound();
            }
            return View(childModel);
        }

        // GET: Child/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Child/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Age,Sex,ReceivedIndemnityForm")] ChildModel childModel)
        {
            if (ModelState.IsValid)
            {
                childModel.ChildId = Guid.NewGuid();
                db.ChildModels.Add(childModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(childModel);
        }

        // GET: Child/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildModel childModel = db.ChildModels.Find(id);
            if (childModel == null)
            {
                return HttpNotFound();
            }
            return View(childModel);
        }

        // POST: Child/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Age,Sex,ReceivedIndemnityForm")] ChildModel childModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(childModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(childModel);
        }

        // GET: Child/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildModel childModel = db.ChildModels.Find(id);
            if (childModel == null)
            {
                return HttpNotFound();
            }
            return View(childModel);
        }

        // POST: Child/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ChildModel childModel = db.ChildModels.Find(id);
            db.ChildModels.Remove(childModel);
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

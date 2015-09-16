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
    public class MedicalInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MedicalInformation
        public ActionResult Index()
        {
            return View(db.MedicalInformationModels.ToList());
        }

        // GET: MedicalInformation/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalInformationModel medicalInformationModel = db.MedicalInformationModels.Find(id);
            if (medicalInformationModel == null)
            {
                return HttpNotFound();
            }
            return View(medicalInformationModel);
        }

        // GET: MedicalInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicalInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Alergies,MedicalAidName,MedicalAidNumber,PrincipalMember,HouseDoctorName,HouseDoctorNumber")] MedicalInformationModel medicalInformationModel)
        {
            if (ModelState.IsValid)
            {
                medicalInformationModel.MedicalInformationId = Guid.NewGuid();
                db.MedicalInformationModels.Add(medicalInformationModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicalInformationModel);
        }

        // GET: MedicalInformation/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalInformationModel medicalInformationModel = db.MedicalInformationModels.Find(id);
            if (medicalInformationModel == null)
            {
                return HttpNotFound();
            }
            return View(medicalInformationModel);
        }

        // POST: MedicalInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Alergies,MedicalAidName,MedicalAidNumber,PrincipalMember,HouseDoctorName,HouseDoctorNumber")] MedicalInformationModel medicalInformationModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicalInformationModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicalInformationModel);
        }

        // GET: MedicalInformation/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalInformationModel medicalInformationModel = db.MedicalInformationModels.Find(id);
            if (medicalInformationModel == null)
            {
                return HttpNotFound();
            }
            return View(medicalInformationModel);
        }

        // POST: MedicalInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            MedicalInformationModel medicalInformationModel = db.MedicalInformationModels.Find(id);
            db.MedicalInformationModels.Remove(medicalInformationModel);
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

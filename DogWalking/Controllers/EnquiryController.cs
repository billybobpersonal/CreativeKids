using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using DogWalking.Models;

namespace DogWalking.Controllers
{
    public class EnquiryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Enquiry
        public ActionResult Index()
        {
            return View(db.EnquiryModels.ToList());
        }

        // GET: Enquiry/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnquiryModel enquiryModel = db.EnquiryModels.Find(id);
            if (enquiryModel == null)
            {
                return HttpNotFound();
            }
            return View(enquiryModel);
        }

        // GET: Enquiry/Create
        public ActionResult CreatePartial()
        {
            return View();
        }

        // GET: Enquiry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Enquiry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EnquiryId,EnquiryDate,FirstName,LastName,ChildAge,ContactNumber,EmailAddress")] EnquiryModel enquiryModel)
        {
            if (ModelState.IsValid)
            {
                enquiryModel.EnquiryId = Guid.NewGuid();
                enquiryModel.EnquiryDate = DateTime.Now;
                db.EnquiryModels.Add(enquiryModel);
                db.SaveChanges();

                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("JeanneMariBasson11@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("RyanBlake101@Gmail.com");  // replace with valid value
                message.Subject = "New Enquiry";
                message.Body = string.Format(body, "Jeanne-Mari Blake", "JeanneMariBasonn11@gmail.com", "Enquiry Created:\n\n Date: \n"+ enquiryModel.EnquiryDate + " First Name: \n" + enquiryModel.FirstName + " Last Name: \n" + enquiryModel.LastName + " Child Age : \n" + enquiryModel.ChildAge + " Contact Number: \n" + enquiryModel.ContactNumber + " Email Address: \n" + enquiryModel.EmailAddress);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "ryanblake101@gmail.com",  // replace with valid value
                        Password = "M0nk3y02"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);                    
                }

                return RedirectToAction("Index");
            }

            return View(enquiryModel);
        }

        // POST: Enquiry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreatePartial([Bind(Include = "EnquiryId,EnquiryDate,FirstName,LastName,ChildAge,ContactNumber,EmailAddress")] EnquiryModel enquiryModel)
        {
            if (ModelState.IsValid)
            {
                enquiryModel.EnquiryId = Guid.NewGuid();
                enquiryModel.EnquiryDate = DateTime.Now;
                db.EnquiryModels.Add(enquiryModel);
                db.SaveChanges();

                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("JeanneMariBasson11@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("RyanBlake101@Gmail.com");  // replace with valid value
                message.Subject = "New Enquiry";
                message.Body = string.Format(body, "Jeanne-Mari Blake", "JeanneMariBasonn11@gmail.com", "Enquiry Created:\n\n Date: \n" + enquiryModel.EnquiryDate + " First Name: \n" + enquiryModel.FirstName + " Last Name: \n" + enquiryModel.LastName + " Child Age : \n" + enquiryModel.ChildAge + " Contact Number: \n" + enquiryModel.ContactNumber + " Email Address: \n" + enquiryModel.EmailAddress);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "ryanblake101@gmail.com",  // replace with valid value
                        Password = "M0nk3y02"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                }

                return RedirectToAction("Index", "Default");
            }

            return View(enquiryModel);
        }

        // GET: Enquiry/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnquiryModel enquiryModel = db.EnquiryModels.Find(id);
            if (enquiryModel == null)
            {
                return HttpNotFound();
            }
            return View(enquiryModel);
        }

        // POST: Enquiry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnquiryId,EnquiryDate,FirstName,LastName,ChildAge,ContactNumber,EmailAddress")] EnquiryModel enquiryModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enquiryModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enquiryModel);
        }

        // GET: Enquiry/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnquiryModel enquiryModel = db.EnquiryModels.Find(id);
            if (enquiryModel == null)
            {
                return HttpNotFound();
            }
            return View(enquiryModel);
        }

        // POST: Enquiry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            EnquiryModel enquiryModel = db.EnquiryModels.Find(id);
            db.EnquiryModels.Remove(enquiryModel);
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

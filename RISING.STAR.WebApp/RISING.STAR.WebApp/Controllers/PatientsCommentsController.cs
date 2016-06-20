using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using RISING.STAR.DAL;
using RISING.STAR.Entities.Results;

namespace RISING.STAR.WebApp.Controllers
{
    public class PatientsCommentsController : Controller
    {
        private RISINGSTAREntities db = new RISINGSTAREntities();

        // GET: PatientsComments
        public ActionResult Index()
        {
            var patientsComments = db.PatientsComments.Include(p => p.Patients_Table).Include(p => p.User);
            return View(patientsComments.ToList());
        }

        // GET: PatientsComments/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientsComment patientsComment = db.PatientsComments.Find(id);
            if (patientsComment == null)
            {
                return HttpNotFound();
            }
            return View(patientsComment);
        }

        // GET: PatientsComments/Create
        public ActionResult Create()
        {
            ViewBag.PatientId = new SelectList(db.Patients_Table, "Guid", "NAME");
            ViewBag.DoctorId = new SelectList(db.Users, "Guid", "Login");
            return View();
        }

        // POST: PatientsComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,PatientId,Comment,Date,DoctorId")] PatientsComment patientsComment)
        {
            //if (ModelState.IsValid)
            //{
            //    patientsComment.CommentId = Guid.NewGuid();
            //    db.PatientsComments.Add(patientsComment);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.PatientId = new SelectList(db.Patients_Table, "Guid", "NAME", patientsComment.PatientId);
            //ViewBag.DoctorId = new SelectList(db.Users, "Guid", "Login", patientsComment.DoctorId);
            //return View(patientsComment);

            patientsComment.CommentId = Guid.NewGuid();
            patientsComment.Date = DateTime.Now;
            patientsComment.DoctorId = Guid.Parse(Session["UserID"].ToString());
            try
            {
                db.PatientsComments.Add(patientsComment);
                db.SaveChanges();
                return Json(new Result("OK", patientsComment.CommentId.ToString()));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // GET: PatientsComments/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientsComment patientsComment = db.PatientsComments.Find(id);
            if (patientsComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientId = new SelectList(db.Patients_Table, "Guid", "NAME", patientsComment.PatientId);
            ViewBag.DoctorId = new SelectList(db.Users, "Guid", "Login", patientsComment.DoctorId);
            return View(patientsComment);
        }

        // POST: PatientsComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,PatientId,Comment,Date,DoctorId")] PatientsComment patientsComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientsComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientId = new SelectList(db.Patients_Table, "Guid", "NAME", patientsComment.PatientId);
            ViewBag.DoctorId = new SelectList(db.Users, "Guid", "Login", patientsComment.DoctorId);
            return View(patientsComment);
        }

        // GET: PatientsComments/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientsComment patientsComment = db.PatientsComments.Find(id);
            if (patientsComment == null)
            {
                return HttpNotFound();
            }
            return View(patientsComment);
        }

        // POST: PatientsComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            PatientsComment patientsComment = db.PatientsComments.Find(id);
            db.PatientsComments.Remove(patientsComment);
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

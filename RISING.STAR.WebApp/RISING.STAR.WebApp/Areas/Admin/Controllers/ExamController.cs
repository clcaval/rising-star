using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RISING.STAR.DAL;

namespace RISING.STAR.WebApp.Areas.Admin.Controllers
{
    public class ExamController : Controller
    {
        private RISINGSTAREntities db = new RISINGSTAREntities();

        // GET: Admin/Exam
        public ActionResult Index()
        {
            var exams_Table = db.Exams_Table.Include(e => e.Patients_Table);
            return View(exams_Table.ToList());
        }

        // GET: Admin/Exam/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exams_Table exams_Table = db.Exams_Table.Find(id);
            if (exams_Table == null)
            {
                return HttpNotFound();
            }
            return View(exams_Table);
        }

        // GET: Admin/Exam/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Patients_Table, "Guid", "NAME");
            return View();
        }

        // POST: Admin/Exam/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PatientId,DateInserted,DateExam,OD_Sph,OD_Cyl,OD_Axis,OS_Sph,OS_Cyl,OS_Axis")] Exams_Table exams_Table)
        {
            if (ModelState.IsValid)
            {
                exams_Table.Id = Guid.NewGuid();
                db.Exams_Table.Add(exams_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Patients_Table, "Guid", "NAME", exams_Table.Id);
            return View(exams_Table);
        }

        // GET: Admin/Exam/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exams_Table exams_Table = db.Exams_Table.Find(id);
            if (exams_Table == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Patients_Table, "Guid", "NAME", exams_Table.Id);
            return View(exams_Table);
        }

        // POST: Admin/Exam/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PatientId,DateInserted,DateExam,OD_Sph,OD_Cyl,OD_Axis,OS_Sph,OS_Cyl,OS_Axis")] Exams_Table exams_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exams_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Patients_Table, "Guid", "NAME", exams_Table.Id);
            return View(exams_Table);
        }

        // GET: Admin/Exam/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exams_Table exams_Table = db.Exams_Table.Find(id);
            if (exams_Table == null)
            {
                return HttpNotFound();
            }
            return View(exams_Table);
        }

        // POST: Admin/Exam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Exams_Table exams_Table = db.Exams_Table.Find(id);
            db.Exams_Table.Remove(exams_Table);
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

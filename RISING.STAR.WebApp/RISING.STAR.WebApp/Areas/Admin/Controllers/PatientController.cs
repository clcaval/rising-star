using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using RISING.STAR.DAL;
using RISING.STAR.WebApp.ActionFilters;

namespace RISING.STAR.WebApp.Areas.Admin.Controllers
{
    [RBAC]
    public class PatientController : Controller
    {

        private RISINGSTAREntities db = new RISINGSTAREntities();

        // GET: Admin/Patient
        public ActionResult Index()
        {
            return View(db.Patients_Table.ToList());
        }

        // GET: Admin/Patient/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patients_Table patients_Table = db.Patients_Table.Find(id);
            if (patients_Table == null)
            {
                return HttpNotFound();
            }
            return View(patients_Table);
        }

        // GET: Admin/Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Patient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Guid,NAME,SURNAME1,REFERENCE,DATE_OF_BIRTH,SEX,ADDRESS,CITY,ZIP,COUNTRY,PHONE,E_MAIL,OBSERVATIONS")] Patients_Table patients_Table)
        {
            if (ModelState.IsValid)
            {
                db.Patients_Table.Add(patients_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patients_Table);
        }

        // GET: Admin/Patient/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patients_Table patients_Table = db.Patients_Table.Find(id);
            if (patients_Table == null)
            {
                return HttpNotFound();
            }
            return View(patients_Table);
        }

        // POST: Admin/Patient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Guid,NAME,SURNAME1,REFERENCE,DATE_OF_BIRTH,SEX,ADDRESS,CITY,ZIP,COUNTRY,PHONE,E_MAIL,OBSERVATIONS")] Patients_Table patients_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patients_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patients_Table);
        }

        // GET: Admin/Patient/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patients_Table patients_Table = db.Patients_Table.Find(id);
            if (patients_Table == null)
            {
                return HttpNotFound();
            }
            return View(patients_Table);
        }

        // POST: Admin/Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Patients_Table patients_Table = db.Patients_Table.Find(id);
            db.Patients_Table.Remove(patients_Table);
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

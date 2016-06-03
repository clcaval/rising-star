using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RISING.STAR.DAL;

namespace RISING.STAR.WebApp.Areas.Intervention.Controllers
{
    public class InterventionEventsController : Controller
    {
        private RISINGSTAREntities db = new RISINGSTAREntities();

        // GET: Intervention/InterventionEvents
        public ActionResult Index()
        {
            var interventionEvents = db.InterventionEvents.Include(i => i.InterventionType).Include(i => i.Patients_Table);
            return View(interventionEvents.ToList());
        }

        // GET: Intervention/InterventionEvents/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterventionEvent interventionEvent = db.InterventionEvents.Find(id);
            if (interventionEvent == null)
            {
                return HttpNotFound();
            }
            return View(interventionEvent);
        }

        // GET: Intervention/InterventionEvents/Create
        public ActionResult Create()
        {
            ViewBag.InterventionTypeGuid = new SelectList(db.InterventionTypes, "InterventionGuid", "Description");
            ViewBag.PatientGuid = new SelectList(db.Patients_Table, "Guid", "NAME");
            return View();
        }

        // POST: Intervention/InterventionEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InterventionEventGuid,PatientGuid,InterventionTypeGuid,Eye,Date")] InterventionEvent interventionEvent)
        {
            if (ModelState.IsValid)
            {
                interventionEvent.InterventionEventGuid = Guid.NewGuid();
                db.InterventionEvents.Add(interventionEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InterventionTypeGuid = new SelectList(db.InterventionTypes, "InterventionGuid", "Description", interventionEvent.InterventionTypeGuid);
            ViewBag.PatientGuid = new SelectList(db.Patients_Table, "Guid", "NAME", interventionEvent.PatientGuid);
            return View(interventionEvent);
        }

        // GET: Intervention/InterventionEvents/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterventionEvent interventionEvent = db.InterventionEvents.Find(id);
            if (interventionEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.InterventionTypeGuid = new SelectList(db.InterventionTypes, "InterventionGuid", "Description", interventionEvent.InterventionTypeGuid);
            ViewBag.PatientGuid = new SelectList(db.Patients_Table, "Guid", "NAME", interventionEvent.PatientGuid);
            return View(interventionEvent);
        }

        // POST: Intervention/InterventionEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InterventionEventGuid,PatientGuid,InterventionTypeGuid,Eye,Date")] InterventionEvent interventionEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interventionEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InterventionTypeGuid = new SelectList(db.InterventionTypes, "InterventionGuid", "Description", interventionEvent.InterventionTypeGuid);
            ViewBag.PatientGuid = new SelectList(db.Patients_Table, "Guid", "NAME", interventionEvent.PatientGuid);
            return View(interventionEvent);
        }

        // GET: Intervention/InterventionEvents/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterventionEvent interventionEvent = db.InterventionEvents.Find(id);
            if (interventionEvent == null)
            {
                return HttpNotFound();
            }
            return View(interventionEvent);
        }

        // POST: Intervention/InterventionEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            InterventionEvent interventionEvent = db.InterventionEvents.Find(id);
            db.InterventionEvents.Remove(interventionEvent);
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

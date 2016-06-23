using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using RISING.STAR.DAL;
using RISING.STAR.WebApp.Areas.Intervention.Models;
using RISING.STAR.Entities.Results;

namespace RISING.STAR.WebApp.Areas.Intervention.Controllers
{
    public class InterventionEventsController : Controller
    {
        private RISINGSTAREntities db = new RISINGSTAREntities();

        // GET: Intervention/InterventionEvents
        public ActionResult Index()
        {
            var interventionEvents = db.InterventionEvents.Include(i => i.InterventionType).Include(i => i.Location).Include(i => i.Patients_Table).Include(i => i.User);
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
            var q = db.InterventionTypes.OrderBy(x => x.Rank);
            ViewBag.InterventionTypeGuid = new SelectList(q, "InterventionGuid", "Description");
            ViewBag.LocationId = new SelectList(db.Locations, "LocationGuid", "Description");
            ViewBag.PatientGuid = new SelectList(db.Patients_Table, "Guid", "NAME");
            ViewBag.DoctorId = new SelectList(db.Users, "Guid", "Login");
            return View();
        }

        // POST: Intervention/InterventionEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InterventionEventGuid,PatientGuid,InterventionTypeGuid,Eye,Date,DoctorId,LocationId")] InterventionEvent interventionEvent)
        {
            try
            {
                db.InterventionEvents.Add(interventionEvent);
                db.SaveChanges();
                return Json(new Result("OK", interventionEvent.InterventionEventGuid.ToString()));
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            var q = db.InterventionTypes.OrderBy(x => x.Rank);
            ViewBag.InterventionTypeGuid = new SelectList(q, "InterventionGuid", "Description", interventionEvent.InterventionTypeGuid);
            ViewBag.LocationId = new SelectList(db.Locations, "LocationGuid", "Description", interventionEvent.LocationId);
            ViewBag.PatientGuid = new SelectList(db.Patients_Table, "Guid", "NAME", interventionEvent.PatientGuid);
            ViewBag.DoctorId = new SelectList(db.Users, "Guid", "Login", interventionEvent.DoctorId);
            return View(interventionEvent);
        }

        // POST: Intervention/InterventionEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InterventionEventGuid,PatientGuid,InterventionTypeGuid,Eye,Date,DoctorId,LocationId")] InterventionEvent interventionEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interventionEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var q = db.InterventionTypes.OrderBy(x => x.Rank);
            ViewBag.InterventionTypeGuid = new SelectList(q, "InterventionGuid", "Description", interventionEvent.InterventionTypeGuid);
            ViewBag.LocationId = new SelectList(db.Locations, "LocationGuid", "Description", interventionEvent.LocationId);
            ViewBag.PatientGuid = new SelectList(db.Patients_Table, "Guid", "NAME", interventionEvent.PatientGuid);
            ViewBag.DoctorId = new SelectList(db.Users, "Guid", "Login", interventionEvent.DoctorId);
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
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            InterventionEvent interventionEvent = db.InterventionEvents.Find(id);
            db.InterventionEvents.Remove(interventionEvent);
            db.SaveChanges();
            return Json(new Result("OK", id.ToString()));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
        /* Intervention view model Create */

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateViewModel(string SelectedEye, DateTime Date, string SelectedIntervention, string PatientGuid)
        //{
        //    var iEvent = new InterventionEvent();
        //    iEvent.InterventionEventGuid = Guid.NewGuid();
        //    iEvent.Eye = SelectedEye;
        //    iEvent.Date = Date;
        //    iEvent.InterventionTypeGuid = Guid.Parse(SelectedIntervention);
        //    iEvent.PatientGuid = Guid.Parse(PatientGuid);
        //    return Create(iEvent);

        //}
        
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CreateViewModel(InterventionViewModel interventionEvent)
        {
            var iEvent = new InterventionEvent();
            iEvent.InterventionEventGuid = Guid.NewGuid();
            iEvent.Eye = interventionEvent.SelectedEye;
            iEvent.Date = interventionEvent.Date;
            iEvent.InterventionTypeGuid = Guid.Parse(interventionEvent.SelectedIntervention);
            iEvent.PatientGuid = interventionEvent.PatientGuid;
            return Create(iEvent);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult EditViewModel(InterventionViewModel interventionEvent)
        {
            var iEvent = new InterventionEvent();
            iEvent.InterventionEventGuid = interventionEvent.InterventionEventGuid;
            iEvent.Eye = interventionEvent.SelectedEye;
            iEvent.Date = interventionEvent.Date;
            iEvent.InterventionTypeGuid = Guid.Parse(interventionEvent.SelectedIntervention);
            iEvent.PatientGuid = interventionEvent.PatientGuid;
            return Edit(iEvent);
        }


    }

}

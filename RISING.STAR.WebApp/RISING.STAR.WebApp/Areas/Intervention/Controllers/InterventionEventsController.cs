using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using RISING.STAR.DAL;
using RISING.STAR.WebApp.Models.OSI;

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
            return Json(View(), JsonRequestBehavior.AllowGet);
        }

        // POST: Intervention/InterventionEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InterventionEventGuid,PatientGuid,InterventionTypeGuid,Eye,Date")] InterventionEvent interventionEvent)
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

            //ViewBag.InterventionTypeGuid = new SelectList(db.InterventionTypes, "InterventionGuid", "Description", interventionEvent.InterventionTypeGuid);
            //ViewBag.PatientGuid = new SelectList(db.Patients_Table, "Guid", "NAME", interventionEvent.PatientGuid);
            ////return Json(View(interventionEvent));
            //return Json("OK");
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
                return Json(new Result("OK", interventionEvent.InterventionEventGuid.ToString()));
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

        // GET: Intervention/InterventionEvents/Create
        public ActionResult CreateViewModel()
        {
            return Create();
        }

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

    public class Result
    {

        public string message { get; set; }
        public string guid { get; set; }

        public Result(string _message, string _guid)
        {
            message = _message;
            guid = _guid;
        }

    }

}

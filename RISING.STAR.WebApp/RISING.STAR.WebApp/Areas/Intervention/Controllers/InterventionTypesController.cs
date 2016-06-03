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
    public class InterventionTypesController : Controller
    {
        private RISINGSTAREntities db = new RISINGSTAREntities();

        // GET: Intervention/InterventionTypes
        public ActionResult Index()
        {
            var interventionTypes = db.InterventionTypes.Include(i => i.InterventionCategory).Include(i => i.InterventionIcon);
            return View(interventionTypes.ToList());
        }

        // GET: Intervention/InterventionTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterventionType interventionType = db.InterventionTypes.Find(id);
            if (interventionType == null)
            {
                return HttpNotFound();
            }
            return View(interventionType);
        }

        // GET: Intervention/InterventionTypes/Create
        public ActionResult Create()
        {
            ViewBag.CategoryGuid = new SelectList(db.InterventionCategories, "CategoryGuid", "CategoryDescription");
            ViewBag.IconGuid = new SelectList(db.InterventionIcons, "InterventionIconGuid", "IconDescription");
            return View();
        }

        // POST: Intervention/InterventionTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InterventionGuid,CategoryGuid,Description,IconGuid")] InterventionType interventionType)
        {
            if (ModelState.IsValid)
            {
                interventionType.InterventionGuid = Guid.NewGuid();
                db.InterventionTypes.Add(interventionType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryGuid = new SelectList(db.InterventionCategories, "CategoryGuid", "CategoryDescription", interventionType.CategoryGuid);
            ViewBag.IconGuid = new SelectList(db.InterventionIcons, "InterventionIconGuid", "IconDescription", interventionType.IconGuid);
            return View(interventionType);
        }

        // GET: Intervention/InterventionTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterventionType interventionType = db.InterventionTypes.Find(id);
            if (interventionType == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryGuid = new SelectList(db.InterventionCategories, "CategoryGuid", "CategoryDescription", interventionType.CategoryGuid);
            ViewBag.IconGuid = new SelectList(db.InterventionIcons, "InterventionIconGuid", "IconDescription", interventionType.IconGuid);
            return View(interventionType);
        }

        // POST: Intervention/InterventionTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InterventionGuid,CategoryGuid,Description,IconGuid")] InterventionType interventionType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interventionType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryGuid = new SelectList(db.InterventionCategories, "CategoryGuid", "CategoryDescription", interventionType.CategoryGuid);
            ViewBag.IconGuid = new SelectList(db.InterventionIcons, "InterventionIconGuid", "IconDescription", interventionType.IconGuid);
            return View(interventionType);
        }

        // GET: Intervention/InterventionTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterventionType interventionType = db.InterventionTypes.Find(id);
            if (interventionType == null)
            {
                return HttpNotFound();
            }
            return View(interventionType);
        }

        // POST: Intervention/InterventionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            InterventionType interventionType = db.InterventionTypes.Find(id);
            db.InterventionTypes.Remove(interventionType);
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

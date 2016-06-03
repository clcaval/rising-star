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
    public class InterventionIconsController : Controller
    {
        private RISINGSTAREntities db = new RISINGSTAREntities();

        // GET: Intervention/InterventionIcons
        public ActionResult Index()
        {
            return View(db.InterventionIcons.ToList());
        }

        // GET: Intervention/InterventionIcons/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterventionIcon interventionIcon = db.InterventionIcons.Find(id);
            if (interventionIcon == null)
            {
                return HttpNotFound();
            }
            return View(interventionIcon);
        }

        // GET: Intervention/InterventionIcons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Intervention/InterventionIcons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InterventionIconGuid,IconDescription,IconFileName")] InterventionIcon interventionIcon)
        {
            if (ModelState.IsValid)
            {
                interventionIcon.InterventionIconGuid = Guid.NewGuid();
                db.InterventionIcons.Add(interventionIcon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(interventionIcon);
        }

        // GET: Intervention/InterventionIcons/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterventionIcon interventionIcon = db.InterventionIcons.Find(id);
            if (interventionIcon == null)
            {
                return HttpNotFound();
            }
            return View(interventionIcon);
        }

        // POST: Intervention/InterventionIcons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InterventionIconGuid,IconDescription,IconFileName")] InterventionIcon interventionIcon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interventionIcon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(interventionIcon);
        }

        // GET: Intervention/InterventionIcons/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterventionIcon interventionIcon = db.InterventionIcons.Find(id);
            if (interventionIcon == null)
            {
                return HttpNotFound();
            }
            return View(interventionIcon);
        }

        // POST: Intervention/InterventionIcons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            InterventionIcon interventionIcon = db.InterventionIcons.Find(id);
            db.InterventionIcons.Remove(interventionIcon);
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

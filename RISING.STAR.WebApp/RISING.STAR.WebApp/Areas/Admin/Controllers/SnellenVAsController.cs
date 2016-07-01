using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RISING.STAR.DAL;
using RISING.STAR.WebApp.ActionFilters;

namespace RISING.STAR.WebApp.Areas.Admin.Controllers
{

    [RBAC]
    public class SnellenVAsController : Controller
    {
        private RISINGSTAREntities db = new RISINGSTAREntities();

        // GET: Admin/SnellenVAs
        public async Task<ActionResult> Index()
        {
            return View(await db.SnellenVAs.ToListAsync());
        }

        // GET: Admin/SnellenVAs/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SnellenVA snellenVA = await db.SnellenVAs.FindAsync(id);
            if (snellenVA == null)
            {
                return HttpNotFound();
            }
            return View(snellenVA);
        }

        // GET: Admin/SnellenVAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SnellenVAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VAID,SnellenVA1")] SnellenVA snellenVA)
        {
            if (ModelState.IsValid)
            {
                snellenVA.VAID = Guid.NewGuid();
                db.SnellenVAs.Add(snellenVA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(snellenVA);
        }

        // GET: Admin/SnellenVAs/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SnellenVA snellenVA = await db.SnellenVAs.FindAsync(id);
            if (snellenVA == null)
            {
                return HttpNotFound();
            }
            return View(snellenVA);
        }

        // POST: Admin/SnellenVAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VAID,SnellenVA1")] SnellenVA snellenVA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(snellenVA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(snellenVA);
        }

        // GET: Admin/SnellenVAs/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SnellenVA snellenVA = await db.SnellenVAs.FindAsync(id);
            if (snellenVA == null)
            {
                return HttpNotFound();
            }
            return View(snellenVA);
        }

        // POST: Admin/SnellenVAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            SnellenVA snellenVA = await db.SnellenVAs.FindAsync(id);
            db.SnellenVAs.Remove(snellenVA);
            await db.SaveChangesAsync();
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

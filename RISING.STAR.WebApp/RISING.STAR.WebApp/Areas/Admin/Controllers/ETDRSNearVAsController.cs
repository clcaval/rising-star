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
    public class ETDRSNearVAsController : Controller
    {
        private RISINGSTAREntities db = new RISINGSTAREntities();

        // GET: Admin/ETDRSNearVAs
        public async Task<ActionResult> Index()
        {
            return View(await db.ETDRSNearVAs.ToListAsync());
        }

        // GET: Admin/ETDRSNearVAs/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ETDRSNearVA eTDRSNearVA = await db.ETDRSNearVAs.FindAsync(id);
            if (eTDRSNearVA == null)
            {
                return HttpNotFound();
            }
            return View(eTDRSNearVA);
        }

        // GET: Admin/ETDRSNearVAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ETDRSNearVAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ETDRSID,ETDRSVA,LogMar,LetterSize,SSMA_TimeStamp")] ETDRSNearVA eTDRSNearVA)
        {
            if (ModelState.IsValid)
            {
                eTDRSNearVA.ETDRSID = Guid.NewGuid();
                db.ETDRSNearVAs.Add(eTDRSNearVA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(eTDRSNearVA);
        }

        // GET: Admin/ETDRSNearVAs/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ETDRSNearVA eTDRSNearVA = await db.ETDRSNearVAs.FindAsync(id);
            if (eTDRSNearVA == null)
            {
                return HttpNotFound();
            }
            return View(eTDRSNearVA);
        }

        // POST: Admin/ETDRSNearVAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ETDRSID,ETDRSVA,LogMar,LetterSize,SSMA_TimeStamp")] ETDRSNearVA eTDRSNearVA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eTDRSNearVA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(eTDRSNearVA);
        }

        // GET: Admin/ETDRSNearVAs/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ETDRSNearVA eTDRSNearVA = await db.ETDRSNearVAs.FindAsync(id);
            if (eTDRSNearVA == null)
            {
                return HttpNotFound();
            }
            return View(eTDRSNearVA);
        }

        // POST: Admin/ETDRSNearVAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ETDRSNearVA eTDRSNearVA = await db.ETDRSNearVAs.FindAsync(id);
            db.ETDRSNearVAs.Remove(eTDRSNearVA);
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

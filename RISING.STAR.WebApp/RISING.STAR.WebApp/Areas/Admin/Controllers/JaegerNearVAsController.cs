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
    public class JaegerNearVAsController : Controller
    {
        private RISINGSTAREntities db = new RISINGSTAREntities();

        // GET: Admin/JaegerNearVAs
        public async Task<ActionResult> Index()
        {
            return View(await db.JaegerNearVAs.ToListAsync());
        }

        // GET: Admin/JaegerNearVAs/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JaegerNearVA jaegerNearVA = await db.JaegerNearVAs.FindAsync(id);
            if (jaegerNearVA == null)
            {
                return HttpNotFound();
            }
            return View(jaegerNearVA);
        }

        // GET: Admin/JaegerNearVAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/JaegerNearVAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "JaegerId,JaegerNVA")] JaegerNearVA jaegerNearVA)
        {
            if (ModelState.IsValid)
            {
                jaegerNearVA.JaegerId = Guid.NewGuid();
                db.JaegerNearVAs.Add(jaegerNearVA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(jaegerNearVA);
        }

        // GET: Admin/JaegerNearVAs/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JaegerNearVA jaegerNearVA = await db.JaegerNearVAs.FindAsync(id);
            if (jaegerNearVA == null)
            {
                return HttpNotFound();
            }
            return View(jaegerNearVA);
        }

        // POST: Admin/JaegerNearVAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "JaegerId,JaegerNVA")] JaegerNearVA jaegerNearVA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jaegerNearVA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(jaegerNearVA);
        }

        // GET: Admin/JaegerNearVAs/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JaegerNearVA jaegerNearVA = await db.JaegerNearVAs.FindAsync(id);
            if (jaegerNearVA == null)
            {
                return HttpNotFound();
            }
            return View(jaegerNearVA);
        }

        // POST: Admin/JaegerNearVAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            JaegerNearVA jaegerNearVA = await db.JaegerNearVAs.FindAsync(id);
            db.JaegerNearVAs.Remove(jaegerNearVA);
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

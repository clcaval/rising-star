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

namespace RISING.STAR.WebApp.Controllers
{

    public class Professor
    {

        public Guid ProfessorId {get;set;}
        public string Name { get; set; }
        public string Courses { get; set; }
        public string Picture { get; set; }

    }
    
    public class UserTestPsController : Controller
    {
        private RISINGSTAREntities db = new RISINGSTAREntities();


        // GET: UserTestPs
        public async Task<ActionResult> Index()
        {
            var list = new List<Professor>();
            foreach (var item in await db.UserTestPs.ToListAsync())
            {
                var p = new Professor();
                p.Courses = item.Courses;
                p.Name = item.Name;
                p.Picture = item.Picture;
                p.ProfessorId = item.ProfessorId;
                list.Add(p);
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // GET: UserTestPs/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTestP userTestP = await db.UserTestPs.FindAsync(id);
            if (userTestP == null)
            {
                return HttpNotFound();
            }
            return Json(userTestP, JsonRequestBehavior.AllowGet);
        }

        // GET: UserTestPs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserTestPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProfessorId,Name,Courses,Picture")] UserTestP userTestP)
        {
            if (ModelState.IsValid)
            {
                userTestP.ProfessorId = Guid.NewGuid();
                db.UserTestPs.Add(userTestP);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return Json(userTestP);
        }

        // GET: UserTestPs/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTestP userTestP = await db.UserTestPs.FindAsync(id);
            if (userTestP == null)
            {
                return HttpNotFound();
            }
            return Json(userTestP, JsonRequestBehavior.AllowGet);
        }

        // POST: UserTestPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProfessorId,Name,Courses,Picture")] UserTestP userTestP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTestP).State = EntityState.Modified;
                await db.SaveChangesAsync();
                //return RedirectToAction("Index");
            }
            return Json(userTestP);
        }

        // GET: UserTestPs/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTestP userTestP = await db.UserTestPs.FindAsync(id);
            if (userTestP == null)
            {
                return HttpNotFound();
            }
            return Json(userTestP, JsonRequestBehavior.AllowGet);
        }

        // POST: UserTestPs/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            UserTestP userTestP = await db.UserTestPs.FindAsync(id);
            db.UserTestPs.Remove(userTestP);
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

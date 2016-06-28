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

    public class ProfessorQ
    {
        public Guid Id { get; set; }
        public Guid ProfessorId { get; set; }
        public string UserName { get; set; }
        public int Didatica { get; set; }
        public int CoerenciaAulaProva { get; set; }
        public int Dominio { get; set; }
        public int Auxilio { get; set; }

    }

    public class UserTestQsController : Controller
    {
        private RISINGSTAREntities db = new RISINGSTAREntities();

        // GET: UserTestQs
        public async Task<ActionResult> Index()
        {
            var userTestQs = db.UserTestQs.Include(u => u.UserTest).Include(u => u.UserTestP);
            var list = new List<ProfessorQ>();
            foreach (var item in userTestQs)
            {
                var pq = new ProfessorQ();
                pq.Auxilio = (int)item.Auxilio;
                pq.CoerenciaAulaProva = (int)item.CoerenciaAulaProva;
                pq.Didatica = (int)item.Didatica;
                pq.Dominio = (int)item.Dominio;
                pq.Id = item.Id;
                pq.ProfessorId = item.ProfessorId;
                pq.UserName = item.UserName;
                list.Add(pq);
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // GET: UserTestQs/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTestQ userTestQ = await db.UserTestQs.FindAsync(id);
            if (userTestQ == null)
            {
                return HttpNotFound();
            }
            return Json(userTestQ, JsonRequestBehavior.AllowGet);
        }

        // GET: UserTestQs/Create
        public ActionResult Create()
        {
            ViewBag.UserName = new SelectList(db.UserTests, "UserName", "Name");
            ViewBag.ProfessorId = new SelectList(db.UserTestPs, "ProfessorId", "Name");
            return View();
        }

        // POST: UserTestQs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ProfessorId,UserName,Didatica,CoerenciaAulaProva,Dominio,Auxilio")] UserTestQ userTestQ)
        {
            try
            {
                userTestQ.Id = Guid.NewGuid();
                db.UserTestQs.Add(userTestQ);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {                
                return Json(ex.Message);
            }

            return Json("OK");
        }

        // GET: UserTestQs/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTestQ userTestQ = await db.UserTestQs.FindAsync(id);
            if (userTestQ == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserName = new SelectList(db.UserTests, "UserName", "Name", userTestQ.UserName);
            ViewBag.ProfessorId = new SelectList(db.UserTestPs, "ProfessorId", "Name", userTestQ.ProfessorId);
            return View(userTestQ);
        }

        // POST: UserTestQs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProfessorId,UserName,Didatica,CoerenciaAulaProva,Dominio,Auxilio")] UserTestQ userTestQ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTestQ).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserName = new SelectList(db.UserTests, "UserName", "Name", userTestQ.UserName);
            ViewBag.ProfessorId = new SelectList(db.UserTestPs, "ProfessorId", "Name", userTestQ.ProfessorId);
            return View(userTestQ);
        }

        // GET: UserTestQs/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTestQ userTestQ = await db.UserTestQs.FindAsync(id);
            if (userTestQ == null)
            {
                return HttpNotFound();
            }
            return Json(userTestQ, JsonRequestBehavior.AllowGet);
        }

        // POST: UserTestQs/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            UserTestQ userTestQ = await db.UserTestQs.FindAsync(id);
            db.UserTestQs.Remove(userTestQ);
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

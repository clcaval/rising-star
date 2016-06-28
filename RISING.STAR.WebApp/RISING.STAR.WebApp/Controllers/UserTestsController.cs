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

using RISING.STAR.Utils.Password;

namespace RISING.STAR.WebApp.Controllers
{
    public class UserTestsController : Controller
    {
        private RISINGSTAREntities db = new RISINGSTAREntities();

        // GET: UserTests
        public async Task<ActionResult> Index()
        {
            return View(await db.UserTests.ToListAsync());
        }

        // GET: UserTests/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTest userTest = await db.UserTests.FindAsync(id);
            if (userTest == null)
            {
                return HttpNotFound();
            }
            return View(userTest);
        }

        // GET: UserTests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserTests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "Name,UserName,Email,Course,PasswordHash")] UserTest userTest)
        {
            try 
	        {

                var userExists = db.UserTests.Where(x => x.UserName == userTest.UserName).FirstOrDefault();
                if (userExists != null)
                    return Json("User already exists.");

                var nameExists = db.UserTests.Where(x => x.Name == userTest.Name).FirstOrDefault();
                if (nameExists != null)
                    return Json("Name already exists");

                var emailExists = db.UserTests.Where(x => x.Email == userTest.Email).FirstOrDefault();
                if (emailExists != null)
                    return Json("Email already exists");

                userTest.PasswordHash = PasswordCreation.CreateHash(userTest.PasswordHash);
                db.UserTests.Add(userTest);
                await db.SaveChangesAsync();
                
	        }
	        catch (Exception)
	        {
		
		        throw;
	        }

            return Json("OK");
        }

        // GET: UserTests/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTest userTest = await db.UserTests.FindAsync(id);
            if (userTest == null)
            {
                return HttpNotFound();
            }
            return Json(userTest, JsonRequestBehavior.AllowGet);
        }

        // POST: UserTests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include = "Name,UserName,Email,Course,PasswordHash")] UserTest userTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTest).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userTest);
        }

        // GET: UserTests/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTest userTest = await db.UserTests.FindAsync(id);
            if (userTest == null)
            {
                return HttpNotFound();
            }
            return View(userTest);
        }

        // POST: UserTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            UserTest userTest = await db.UserTests.FindAsync(id);
            db.UserTests.Remove(userTest);
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

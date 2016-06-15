using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using RISING.STAR.DAL;
using RISING.STAR.Utils.Password;

namespace RISING.STAR.WebApp.Areas.UserAndRole.Controllers
{
    public class UsersController : Controller
    {
        private RISINGSTAREntities db = new RISINGSTAREntities();

        // GET: UserAndRole/Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: UserAndRole/Users/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: UserAndRole/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAndRole/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Guid,Active,DateCreated,DateLastModified,LastModifiedBy,Login,PasswordHash,IsADM,EmailAddress,ResetPassword")] User user)
        {

            if(user != null)
            {
                user.Active = true;
                user.DateCreated = DateTime.Now;
                user.DateLastModified = DateTime.Now;
                user.LastModifiedBy = 0;
                user.ResetPassword = false;
                user.PasswordHash = PasswordCreation.CreateHash(user.PasswordHash);
            }

            if (ModelState.IsValid)
            {
                user.Guid = Guid.NewGuid();
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: UserAndRole/Users/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: UserAndRole/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Guid,Active,DateCreated,DateLastModified,LastModifiedBy,Login,PasswordHash,IsADM,EmailAddress,ResetPassword")] User user)
        {
            if(user != null)
            {
                user.Active = true;
                user.DateCreated = DateTime.Now;
                user.DateLastModified = DateTime.Now;
                user.LastModifiedBy = 0;
                user.ResetPassword = false;
            }

            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: UserAndRole/Users/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: UserAndRole/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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

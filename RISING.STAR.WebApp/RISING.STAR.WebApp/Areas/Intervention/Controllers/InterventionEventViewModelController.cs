using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RISING.STAR.WebApp.Areas.Intervention.Controllers
{
    public class InterventionEventViewModelController : Controller
    {
        // GET: Intervention/InterventionEventViewModel
        public ActionResult Index()
        {
            return View();
        }

        // GET: Intervention/InterventionEventViewModel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Intervention/InterventionEventViewModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Intervention/InterventionEventViewModel/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Intervention/InterventionEventViewModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Intervention/InterventionEventViewModel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Intervention/InterventionEventViewModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Intervention/InterventionEventViewModel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

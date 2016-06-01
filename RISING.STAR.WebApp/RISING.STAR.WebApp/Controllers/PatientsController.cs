using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RISING.STAR.Business.PatientBusiness;


namespace RISING.STAR.WebApp.Controllers
{
    public class PatientsController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPatients()
        {
            PatientBusiness pb = new PatientBusiness();
            return Json(pb.RetrieveAllPatients(), JsonRequestBehavior.AllowGet);
        }

        [ChildActionOnly]
        public ActionResult GetAllPatients()
        {
            PatientBusiness pb = new PatientBusiness();
            var patList = pb.RetrieveAllPatients();
            ViewBag.Patients = new SelectList
                (patList,
                    "Id",
                    "Name",
                    0);

            return PartialView(patList);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RISING.STAR.WebApp.ActionFilters;

using RISING.STAR.Business.AcuDataMetrics;
using RISING.STAR.Entities.AcuDataTarget;

namespace RISING.STAR.WebApp.Areas.AcuTargetMetrics.Controllers
{

    [RBAC]
    public class AcuTargetMetricsController : Controller
    {

        private AcuTargetMetricsBusiness acuTargBusiness;

        public AcuTargetMetricsController()
        {
            acuTargBusiness = new AcuTargetMetricsBusiness();
        }
        // GET: AcuTargetMetrics
        public ActionResult Index()
        {
            return View();
        }
                
        //[HttpPost]
        public ActionResult Graph(Guid ids, string exam, string name, string section, string cords, string angle, string x, string y, string purkX, string purkY, int type, string eye)
        {
            return View();
        }

        public JsonResult GetOSIs(Guid patientId)
        {
            return Json(acuTargBusiness.RetrieveOSI(patientId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPseudoAccomodation(Guid patientId)
        {
            return Json(acuTargBusiness.RetrievePseudoAccomodation(patientId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTearFilmOSI(Guid patientId)
        {
            return Json(acuTargBusiness.RetrieveTearFilmOSI(patientId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPurkinjeVsPupil(Guid patientId)
        {
            return Json(acuTargBusiness.RetrievePurkinjeVsPupil(patientId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetInlayVsPurkinje(Guid patientId)
        {
            return Json(acuTargBusiness.RetrieveInlayVsPurkinje(patientId), JsonRequestBehavior.AllowGet);
        }

    }
}
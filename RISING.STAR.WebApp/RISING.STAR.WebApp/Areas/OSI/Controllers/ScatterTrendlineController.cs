using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RISING.STAR.WebApp.Models.Intervention;
using RISING.STAR.Business.OSI;
using RISING.STAR.Business.Intervention;
using RISING.STAR.Utils.Helper;

namespace RISING.STAR.WebApp.Areas.OSI.Controllers
{
    public class ScatterTrendlineController : Controller
    {
        // GET: OSI/ScatterTrendline
        //[HttpGet]
        //public ActionResult Index()
        //{
        //    var ivm = this.GetInterventionViewModel(Guid.Empty);
        //    return View(ivm);
        //}

        public ActionResult Index(Guid id)
        {
            var ivm = this.GetInterventionViewModel(id);
            return View(ivm);
        }

        [HttpGet]
        public ActionResult RetrieveAcquisitions(Guid patientId, String eye, DateTime initialDate, DateTime finalDate)
        {
            var bussTrend = new OSITrendlineBusiness();
            var acqList = bussTrend.RetrieveOSITrendline(patientId, eye, initialDate, finalDate);            
            return Json(acqList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetInterventions(Guid patientId, String eye, DateTime initialDate, DateTime finalDate)
        {
            var intBuss = new InterventionBusiness();
            var intList = intBuss.GetAllEventsFromPatient(patientId, eye, initialDate, finalDate);

            return Json(intList, JsonRequestBehavior.AllowGet);
        }

        private InterventionViewModel GetInterventionViewModel(Guid id)
        {
            var ivm = new InterventionViewModel();

            ivm.Eye.Add(new SelectListItem { Text = "OD", Value = "OD" });
            ivm.Eye.Add(new SelectListItem { Text = "OS", Value = "OS" });

            var intBusiness = new InterventionBusiness();
            ivm.Intervention = intBusiness.GetAllInterventionTypes().Select(x =>
                                new SelectListItem
                                {
                                    Value = x.InterventionGuid.ToString(),
                                    Text = x.Description
                                }).ToList();

            ivm.InterventionEvents = intBusiness.GetAllEventsFromPatient(id);
            
            return ivm;
        }
        
    }
}

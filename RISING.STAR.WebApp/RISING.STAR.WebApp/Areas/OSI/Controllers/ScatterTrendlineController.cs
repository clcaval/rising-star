using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RISING.STAR.WebApp.Models.OSI;
using RISING.STAR.Business.OSI;
using RISING.STAR.Utils.Helper;

namespace RISING.STAR.WebApp.Areas.OSI.Controllers
{
    public class ScatterTrendlineController : Controller
    {
        // GET: OSI/ScatterTrendline
        //public ActionResult Index()
        //{
        //    return View();
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

        private InterventionViewModel GetInterventionViewModel(Guid id)
        {
            var ivm = new InterventionViewModel();

            ivm.Eye.Add(new SelectListItem { Text = "OD", Value = "OD" });
            ivm.Eye.Add(new SelectListItem { Text = "OS", Value = "OS" });

            var osiTrendBuss = new OSITrendlineBusiness();
            ivm.Intervention = osiTrendBuss.GetAllInterventionTypes().Select(x =>
                                new SelectListItem
                                {
                                    Value = x.InterventionGuid.ToString(),
                                    Text = x.Description
                                }).ToList();

            ivm.InterventionEvents = osiTrendBuss.GetAllEventsFromPatient(id);
            
            return ivm;
        }


        
    }
}

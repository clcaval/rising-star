using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RISING.STAR.Business.TearFilm;
using RISING.STAR.WebApp.Areas.Intervention.Models;
using RISING.STAR.Business.Intervention;

namespace RISING.STAR.WebApp.Areas.TearFilm.Controllers
{
    public class TrendlineController : Controller
    {
        // GET: TearFilm/Trendline
        public ActionResult Index(Guid id)
        {
            var ivm = this.GetInterventionViewModel(id);
            return View(ivm);
        }

        [HttpGet]
        public ActionResult RetrieveAcquisitions(Guid patientId, String eye, DateTime initialDate, DateTime finalDate)
        {
            var bussTrend = new TearFilmBusiness();
            var acqList = bussTrend.RetrieveTearFilmTrendline(patientId, eye, initialDate, finalDate);
            return Json(acqList, JsonRequestBehavior.AllowGet);
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
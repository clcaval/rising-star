using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RISING.STAR.WebApp.Models.OSI;
using RISING.STAR.Business.OSI;

namespace RISING.STAR.WebApp.Areas.OSI.Controllers
{
    public class ScatterTrendlineController : Controller
    {
        // GET: OSI/ScatterTrendline
        //public ActionResult Index()
        //{
        //    return Index(new Guid());
        //}

        public ActionResult Index(Guid id)
        {
            return View(GetInterventionViewModel(id));
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
            
            return ivm;
        }
        
    }
}


//ivm.Treatment.Add(new SelectListItem { Text = "Treatment1", Value = "Guid1"} );
//ivm.Treatment.Add(new SelectListItem { Text = "Treatment2", Value = "Guid2"} );
//ivm.Treatment.Add(new SelectListItem { Text = "Treatment3", Value = "Guid3"} );


//var locs  = locBuss.RetrieveLocations().Select(x =>
//    new SelectListItem
//    {
//        Value = x.LocationGuid.ToString(),
//        Text = x.Description
//    }
//);
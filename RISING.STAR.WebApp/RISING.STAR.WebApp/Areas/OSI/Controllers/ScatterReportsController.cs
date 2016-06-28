using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RISING.STAR.Business.Intervention;
using RISING.STAR.WebApp.Areas.OSI.Models;

using RISING.STAR.WebApp.ActionFilters;

namespace RISING.STAR.WebApp.Areas.OSI.Controllers
{

    [RBAC]
    public class ScatterReportsController : Controller
    {
        // GET: OSI/ScatterReports
        public ActionResult Index()
        {

            var viewModel = new OSIReportViewModel();

            viewModel.StartAge = 18;

            var intBusiness = new InterventionBusiness();
            viewModel.FirstCriteria = intBusiness.GetAllInterventionTypes().Select(x =>
                                new SelectListItem
                                {
                                    Value = x.InterventionGuid.ToString(),
                                    Text = x.Description
                                }).ToList();

            viewModel.SecondCriteria = viewModel.FirstCriteria;

            // Start Range
            viewModel.StartRange = this.GetStartRange().ToList();

            // End Range
            viewModel.EndRange = this.GetEndRange().ToList();
               
            // Frequency
            viewModel.Frequency = this.GetFrequency().ToList();

            return View(viewModel);
        }
        
        [HttpGet]
        public ActionResult RetrieveOSICohort(OSIReportViewModel viewModel)
        {
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
        
        private List<SelectListItem> GetStartRange()
        {
            var list = new List<SelectListItem>();
            for (int i = 1; i <= 12; i++)
            {
                list.Add(new SelectListItem
                {
                    Value = i.ToString(),
                    Text = i.ToString()
                });
            }
            return list;
        }
        
        private List<SelectListItem> GetEndRange()
        {
            var list = new List<SelectListItem>();
            for (int i = 1; i <= 5; i++)
            {
                list.Add(new SelectListItem
                {
                    Value = i.ToString(),
                    Text = i.ToString()
                });
            }

            for (int i = 30; i <= 150; i += 30)
            {
                list.Add(new SelectListItem
                {
                    Value = i.ToString(),
                    Text = i.ToString()
                });
            }
            return list;
        }

        private List<SelectListItem> GetFrequency()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem { Value = "D", Text = "Days" });
            list.Add(new SelectListItem { Value = "W", Text = "Weeks" });
            list.Add(new SelectListItem { Value = "M", Text = "Months" });
            list.Add(new SelectListItem { Value = "Y", Text = "Years" });
            return list;
        }

    }
}
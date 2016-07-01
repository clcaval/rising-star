using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RISING.STAR.Business.Intervention;
using RISING.STAR.Business.OSI;
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
            //viewModel.StartRange = this.GetStartRange().ToList();

            // End Range
            //viewModel.EndRange = this.GetEndRange().ToList();
               
            // Frequency
            viewModel.Timewindow = this.GetTimewindow().ToList();

            return View(viewModel);
        }
        
        [HttpGet]
        public ActionResult RetrieveOSICohort(OSIReportViewModel viewModel)
        {

            var buss = new OSITrendlineBusiness();
            var data = buss.RetrieveOSICohort(viewModel.StartAge, viewModel.EndAge, 
                                                viewModel.SelectedFirstCriteria, viewModel.SelectedSecondCriteria,
                                                viewModel.SelectedTimewindow,
                                                viewModel.StartDateRange,
                                                viewModel.EndDateRange);

            return Json(data, JsonRequestBehavior.AllowGet);
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

        private List<SelectListItem> GetTimewindow()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem { Value = "1W", Text = "1 week" });
            list.Add(new SelectListItem { Value = "1M", Text = "1 month" });
            list.Add(new SelectListItem { Value = "3M", Text = "3 months" });
            list.Add(new SelectListItem { Value = "6M", Text = "6 months" });
            list.Add(new SelectListItem { Value = "1Y", Text = "1 year" });
            list.Add(new SelectListItem { Value = "2Y", Text = "2 years" });
            list.Add(new SelectListItem { Value = "3Y", Text = "3 years" });
            list.Add(new SelectListItem { Value = "5Y", Text = "5 years" });
            return list;
        }

    }
}
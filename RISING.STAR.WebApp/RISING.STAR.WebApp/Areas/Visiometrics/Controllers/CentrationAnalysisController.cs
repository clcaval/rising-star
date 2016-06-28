using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RISING.STAR.WebApp.ActionFilters;

namespace RISING.STAR.WebApp.Areas.Visiometrics.Controllers
{

    [RBAC]
    public class CentrationAnalysisController : Controller
    {
        // GET: Visiometrics/CentrationAnalysis
        public ActionResult Index()
        {
            return View();
        }
    }
}
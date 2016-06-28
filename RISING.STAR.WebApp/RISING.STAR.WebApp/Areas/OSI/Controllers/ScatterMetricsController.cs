using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RISING.STAR.WebApp.ActionFilters;

namespace RISING.STAR.WebApp.Areas.OSI.Controllers
{
    [RBAC]
    public class ScatterMetricsController : Controller
    {
        // GET: OSI/ScatterMetrics
        public ActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RISING.STAR.WebApp.ActionFilters;

namespace RISING.STAR.WebApp.Areas.Visiometrics.Controllers
{

    [RBAC]
    public class NearVisionVsTearFilmOSIController : Controller
    {
        // GET: Visiometrics/NearVisionVsTearFilmOSI
        public ActionResult Index()
        {
            return View();
        }
    }
}
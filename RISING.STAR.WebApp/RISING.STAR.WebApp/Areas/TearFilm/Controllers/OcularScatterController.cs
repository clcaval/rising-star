using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RISING.STAR.WebApp.ActionFilters;

namespace RISING.STAR.WebApp.Areas.TearFilm.Controllers
{


    [RBAC]
    public class OcularScatterController : Controller
    {
        // GET: TearFilm/OcularScatter
        public ActionResult Index()
        {
            return View();
        }
    }
}
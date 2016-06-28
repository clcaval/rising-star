using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RISING.STAR.WebApp.ActionFilters;

namespace RISING.STAR.WebApp.Controllers
{
     [RBAC]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

    }
}
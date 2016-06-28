using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RISING.STAR.WebApp.ActionFilters;

namespace RISING.STAR.WebApp.Areas.Admin.Controllers
{

    [RBAC]
    public class AdminDashController : Controller
    {
        // GET: Admin/AdminDash
        public ActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RISING.STAR.WebApp.Areas.Admin.Controllers
{
    public class AdminDashController : Controller
    {
        // GET: Admin/AdminDash
        public ActionResult Index()
        {
            return View();
        }
    }
}
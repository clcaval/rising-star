﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RISING.STAR.WebApp.ActionFilters;
using RISING.STAR.Business.PatientBusiness;
using RISING.STAR.WebApp.Models;

namespace RISING.STAR.WebApp.Controllers
{

    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {            
            return View();
        }    
    }
}

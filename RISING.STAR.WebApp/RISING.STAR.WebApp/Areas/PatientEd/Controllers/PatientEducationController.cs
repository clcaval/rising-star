﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RISING.STAR.WebApp.ActionFilters;

namespace RISING.STAR.WebApp.Areas.PatientEd.Controllers
{

    [RBAC]
    public class PatientEducationController : Controller
    {
        // GET: PatientEd/PatientEducation
        public ActionResult Index()
        {
            return View();
        }
    }
}
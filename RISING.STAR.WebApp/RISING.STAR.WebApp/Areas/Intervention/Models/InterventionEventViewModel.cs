﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RISING.STAR.DAL;

namespace RISING.STAR.WebApp.Areas.Intervention.Models
{
    public class InterventionEventViewModel
    {

        public IEnumerable<InterventionEvent> InterventionEvents { get; set; }

    }
}
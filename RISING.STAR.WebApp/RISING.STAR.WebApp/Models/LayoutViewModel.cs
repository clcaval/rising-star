using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RISING.STAR.Entities.Patients;
using System.Web.Mvc;

namespace RISING.STAR.WebApp.Models
{
    public class LayoutViewModel
    {
        public IEnumerable<SelectListItem> Patients { get; set; }
        public int SelectedPatientId { get; set; } 

    }
}
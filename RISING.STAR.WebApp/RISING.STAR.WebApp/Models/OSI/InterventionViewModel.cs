using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RISING.STAR.DAL;

namespace RISING.STAR.WebApp.Models.OSI
{
    public class InterventionViewModel
    {

        public List<SelectListItem> Eye { get; set; }
        public string SelectedEye { get; set; }

        public List<SelectListItem> Intervention { get; set; }
        public string SelectedIntervention {get;set;}

        public DateTime Date { get; set; }
        
        public Guid PatientId { get; set; }

        public IEnumerable<InterventionEvent> InterventionEvents { get; set; }

        public InterventionViewModel()
        {
            this.Eye = new List<SelectListItem>();
            this.Intervention = new List<SelectListItem>();
        }

    }
}
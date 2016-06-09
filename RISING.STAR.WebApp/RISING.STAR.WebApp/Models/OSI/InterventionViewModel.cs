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

        // {"InterventionEventGuid":"","PatientGuid":"6b961406-2803-42b1-a9d2-489350c84a1b","SelectedIntervention":"f2964fb8-41dd-438f-90e0-0e248bb7b541","SelectedEye":"OD","Date":"06/29/2016"}
        
        public List<SelectListItem> Eye { get; set; }
        public string SelectedEye { get; set; }

        public List<SelectListItem> Intervention { get; set; }
        public string SelectedIntervention {get;set;}

        public DateTime Date { get; set; }

        public Guid PatientGuid { get; set; }

        public Guid InterventionEventGuid { get; set; }
        public IEnumerable<InterventionEvent> InterventionEvents { get; set; }

        public InterventionViewModel()
        {
            this.Eye = new List<SelectListItem>();
            this.Intervention = new List<SelectListItem>();
        }

    }
}
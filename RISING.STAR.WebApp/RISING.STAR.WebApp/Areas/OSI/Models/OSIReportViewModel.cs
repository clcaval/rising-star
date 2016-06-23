using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RISING.STAR.DAL;
using System.Web.Mvc;

namespace RISING.STAR.WebApp.Areas.OSI.Models
{
    public class OSIReportViewModel
    {

        public int StartAge { get; set; }
        public int EndAge { get; set; }

        public List<SelectListItem> FirstCriteria { get; set; }
        public Guid SelectedFirstCriteria { get; set; }

        public List<SelectListItem> SecondCriteria { get; set; }
        public Guid SelectedSecondCriteria { get; set; }

        public List<SelectListItem> StartRange { get; set; }
        public int SelectedStartRange { get; set; }

        public List<SelectListItem> EndRange { get; set; }
        public int SelectedEndRange { get; set; }

        public List<SelectListItem> Frequency { get; set; }
        public string SelectedFrequency { get; set; }

        public DateTime StartDateRange { get; set; }
        public DateTime EndDateRange { get; set; }

    }
}
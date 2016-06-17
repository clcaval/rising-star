using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RISING.STAR.WebApp.Models.TreatmentHistory
{
    public class TreatmentHistoryAcquisition
    {

        public string AcquisitionDescription { get; set; }
        public string Eye { get; set; }
        public DateTime Date { get; set; } 

        public TreatmentHistoryAcquisition(string _acquisitionDescription, string _eye, DateTime _date)
        {
            this.AcquisitionDescription = _acquisitionDescription;
            this.Eye = _eye;
            this.Date = _date;
        }

    }
}
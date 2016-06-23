using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RISING.STAR.WebApp.Areas.TestingTreatment.Models
{
    public class TreatmentHistoryIntervention
    {

        public Guid InterventionTypeGuid { get; set; }
        public string InterventionDescription { get; set; }
        public string Eye { get; set; }
        public DateTime InsertionDate { get; set; }

        public TreatmentHistoryIntervention(Guid _interventionTypeGuid, string _interventionDescription, string _eye, DateTime _insertionDate)
        {
            this.InterventionTypeGuid = _interventionTypeGuid;
            this.InterventionDescription = _interventionDescription;
            this.Eye = _eye;
            this.InsertionDate = _insertionDate;
        }
        
    }
}
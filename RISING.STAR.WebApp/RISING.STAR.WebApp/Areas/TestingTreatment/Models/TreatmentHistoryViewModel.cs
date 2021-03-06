﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RISING.STAR.DAL;
using RISING.STAR.Business.Intervention;

namespace RISING.STAR.WebApp.Areas.TestingTreatment.Models
{
    public class TreatmentHistoryViewModel
    {

        public List<TreatmentHistoryIntervention> InterventionList { get; set; }
        public List<TreatmentHistoryAcquisition> Acquisitions { get; set; }
        public List<PatientsComment> PatientsComments { get; set; }

        public String Comment { get; set; }
        public Guid PatientId { get; set; }
        
        public TreatmentHistoryViewModel()
        {
            this.InterventionList = new List<TreatmentHistoryIntervention>();
            this.Acquisitions = new List<TreatmentHistoryAcquisition>();
            this.PatientsComments = new List<PatientsComment>();
        }
        
    }
}
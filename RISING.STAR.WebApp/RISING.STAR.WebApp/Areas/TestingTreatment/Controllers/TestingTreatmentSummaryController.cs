using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RISING.STAR.Business.Intervention;
using RISING.STAR.Business.Acquisition;
using RISING.STAR.Business.PatientBusiness;

using RISING.STAR.WebApp.Models.TreatmentHistory;

namespace RISING.STAR.WebApp.Areas.TestingTreatment.Controllers
{
    public class TestingTreatmentSummaryController : Controller
    {
        // GET: TestingTreatment/TestingTreatmentSummary
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Index(Guid id)
        {

            var viewModel = new TreatmentHistoryViewModel();

            var ib = new InterventionBusiness();
            var ia = new AcquisitionBusiness();
            var pat = new PatientBusiness();

            var ints = ib.GetAllEventsFromPatient(id);
            var acqs = ia.RetrieveAcquisition(id).Where(x => x.Type_Num != null &&
                                                                !String.IsNullOrEmpty(x.Type));
            var comms = pat.GetPatientComments(id);

            foreach (var item in ints)
            {
                var intTreat = new TreatmentHistoryIntervention(item.InterventionType.InterventionGuid,
                                                                    item.InterventionType.Description,
                                                                    item.Eye,
                                                                    item.Date);

                viewModel.InterventionList.Add(intTreat);
            }

            foreach (var item in acqs)
            {
                var acqTreat = new TreatmentHistoryAcquisition(item.Type,
                                                                item.OS_OD,
                                                                item.DATE);
                viewModel.Acquisitions.Add(acqTreat);
            }

            viewModel.PatientsComments = pat.GetPatientComments(id).ToList();

            viewModel.Acquisitions.OrderByDescending(x => x.Date);
            viewModel.InterventionList.OrderByDescending(x => x.InsertionDate);
            viewModel.PatientsComments.OrderByDescending(x => x.Date);

            return View(viewModel);

        }
        
    }
}
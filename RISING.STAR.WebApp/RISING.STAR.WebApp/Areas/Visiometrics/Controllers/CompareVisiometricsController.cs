using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RISING.STAR.Business.PatientBusiness;
using RISING.STAR.WebApp.Areas.Visiometrics.Models;
using RISING.STAR.WebApp.ActionFilters;

namespace RISING.STAR.WebApp.Areas.Visiometrics.Controllers
{

    [RBAC]
    public class CompareVisiometricsController : Controller
    {
        // GET: Visiometrics/CompareVisiometrics
        public ActionResult Index(Guid id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult RetrieveExams(Guid patientId, int type)
        {

            var docBuss = new PatientBusiness();
            var list = docBuss.GetPatientDocuments(patientId, type).Select(x =>
                            new Document
                            {
                                DocumentId = x.DocumentId,
                                DocumentDate = x.DocumentDate,
                                DocumentName = x.FileName,
                                DocumentDisplay = String.Format("{0} - {1}: {2}", x.ExamType1.ExamTypeName, x.Eye, ((DateTime)x.DocumentDate).ToString("G")), //MM/dd/yyyy HH:mm:ss
                            }
                );

            return Json(list, JsonRequestBehavior.AllowGet);

        }

    }
}
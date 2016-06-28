using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RISING.STAR.WebApp.Areas.Visiometrics.Models;
using RISING.STAR.Business.PatientBusiness;
using RISING.STAR.WebApp.ActionFilters;

namespace RISING.STAR.WebApp.Areas.Visiometrics.Controllers
{

    [RBAC]
    public class VisiometricController : Controller
    {
        // GET: Visiometrics/VisiometricsReports
        public ActionResult Index(Guid id)
        {

            var patBuss = new PatientBusiness();
            var viewModel = new VisiometricsViewModel();
            var list = new List<Document>();
            var docs = patBuss.GetPatientDocuments(id);

            foreach (var item in docs)
            {
                var document = new Document();
                document.DocumentId = item.DocumentId;
                document.DocumentName = item.FileName;
                document.DocumentDate = item.DocumentDate;
                list.Add(document);
            }

            viewModel.Documents = list;
            return View(viewModel);

        }
    }
}
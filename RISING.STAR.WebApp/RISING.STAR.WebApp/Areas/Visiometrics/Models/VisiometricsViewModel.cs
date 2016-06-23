using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RISING.STAR.WebApp.Areas.Visiometrics.Models
{
    public class VisiometricsViewModel
    {

        public IEnumerable<Document> Documents { get; set; }

        public VisiometricsViewModel() {
            this.Documents = new List<Document>();
        }

    }
}
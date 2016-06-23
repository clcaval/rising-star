using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RISING.STAR.WebApp.Areas.Visiometrics.Models
{
    public class Document
    {

        public Guid DocumentId { get; set; }
        public String DocumentName { get; set; }
        public DateTime DocumentDate { get; set; }
        public String DocumentDisplay { get; set; }

        public Document() { }

        public Document(Guid _docId, string _docName, DateTime _docDate, string _docDisplay)
        {
            this.DocumentId = _docId;
            this.DocumentName = _docName;
            this.DocumentDate = _docDate;
            this.DocumentDisplay = _docDisplay;
        }
        
    }
}
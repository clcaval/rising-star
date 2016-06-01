using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISING.STAR.Entities.AcuDataTarget
{
    public class ReportBase
    {

        public int AcqId { get; set; }
        public String ExamDate { get; set; }
        public String ExamTime { get; set; }
        public String ExamEye { get; set; }

        public ReportBase(int _acqId, String _examDate, String _examTime, String _examEye)
        {
            this.AcqId = _acqId;
            this.ExamDate = _examDate;
            this.ExamTime = _examTime;
            this.ExamEye = _examEye;
        }

    }
}

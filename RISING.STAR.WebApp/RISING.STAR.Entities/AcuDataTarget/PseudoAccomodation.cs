using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISING.STAR.Entities.AcuDataTarget
{
    public class PseudoAccomodation : ReportBase
    {

        public float OAR { get; set; }

        public PseudoAccomodation(int _acqId, String _examDate, String _examTime, String _examEye, float _oar)
                : base(_acqId, _examDate, _examTime, _examEye)
        {
            this.OAR = _oar;
        }

    }
}

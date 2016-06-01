using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISING.STAR.Entities.AcuDataTarget
{
    public class OSIBase : ReportBase 
    {
        
        public float OSI { get; set; }

        public OSIBase(int _acqId, String _examDate, String _examTime, String _examEye, float _osi)
                : base (_acqId, _examDate, _examTime, _examEye)
        {
            this.OSI = _osi;
        }

    }
}

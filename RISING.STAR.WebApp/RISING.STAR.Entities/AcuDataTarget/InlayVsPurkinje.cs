using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISING.STAR.Entities.AcuDataTarget
{
    public class InlayVsPurkinje : ReportBase
    {

        public float X { get; set; }
        public float Y {get;set;}

        public InlayVsPurkinje(int _acqId, String _examDate, String _examTime, String _examEye, float _x, float _y)
                : base (_acqId, _examDate, _examTime, _examEye)
        {
            this.X = _x;
            this.Y = _y;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISING.STAR.Entities.AcuDataTarget
{
    public class TearFilmOSI : OSIBase
    {

        public float StDev { get; set; }

        public TearFilmOSI(int _acqId, String _examDate, String _examTime, String _examEye, float _osi, float _stDev)
            : base (_acqId, _examDate, _examTime, _examEye, _osi) {
                this.StDev = _stDev;
        }

    }
}

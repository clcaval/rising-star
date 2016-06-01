using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISING.STAR.Entities.AcuDataTarget
{
    public class PurkinjeVSPupilMetrics : PurkinjeBase
    {
                
        public PurkinjeVSPupilMetrics(int _acqId, String _examDate, String _examTime, String _examEye, float _coord, float _angle, float _x, float _y)
                : base (_acqId, _examDate, _examTime, _examEye, _coord, _angle, _x, _y)
        {
        }

    }
}

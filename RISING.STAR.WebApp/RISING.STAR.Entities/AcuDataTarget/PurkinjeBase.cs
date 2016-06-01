using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISING.STAR.Entities.AcuDataTarget
{
    public class PurkinjeBase : ReportBase
    {

        public float Coord { get; set; }
        public float Angle { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

        public PurkinjeBase(int _acqId, String _examDate, String _examTime, String _examEye, float _coord, float _angle, float _x, float _y)
                : base (_acqId, _examDate, _examTime, _examEye)
        {
            this.Coord = _coord;
            this.Angle = _angle;
            this.X = _x;
            this.Y = _y;
        }

    }
}

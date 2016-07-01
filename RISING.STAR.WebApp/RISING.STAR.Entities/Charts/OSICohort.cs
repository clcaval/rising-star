using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISING.STAR.Entities.Charts
{
    public class OSICohort
    {

        public string name { get; set; }
        public List<double[]> data { get; set; }
        public string color { get; set; }

        public OSICohort()
        {
            this.data = new List<double[]>();
            // this.color = "rgba(119, 152, 191, .5)";
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISING.STAR.Entities.Charts
{
    public class InterventionData
    {

        // interventions.push({ 'date': date, 'icon': icon , display: date.format('MMM/YYYY') });

        public DateTime date { get; set; }
        public string icon { get; set; }
        public string display { get; set; }
        
    }
}

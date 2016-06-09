using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISING.STAR.Entities.Charts
{
    public class BaseEntity
    {
        public DateTime Date { get; set; }
        public float? Value { get; set; }
        public string DisplayX { get; set; }
    }
}

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

        public BaseEntity() { }

        public BaseEntity(DateTime _Date, float? _Value, string _DisplayX) {
            this.Date = _Date;
            this.Value = _Value;
            this.DisplayX = _DisplayX;
        }

    }
}

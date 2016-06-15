using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISING.STAR.Entities.Charts
{
    public class TrendlineData : BaseEntity
    {

        public string Icon { get; set; }

        public TrendlineData() { }

        public TrendlineData(DateTime _Date, float? _Value, string _DisplayX) : base(_Date, _Value, _DisplayX) { }

        public TrendlineData(DateTime _Date, float? _Value, string _DisplayX, string _Icon) : base(_Date, _Value, _DisplayX)
        {
            this.Icon = _Icon;
        }
                
    }
}

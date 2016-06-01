using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RISING.STAR.DAL;

namespace RISING.STAR.Business.Common
{
    public class CommonBusiness
    {

        private RISINGSTAREntities dbContext;

        public CommonBusiness()
        {
            dbContext = new RISINGSTAREntities();
        }


    }
}

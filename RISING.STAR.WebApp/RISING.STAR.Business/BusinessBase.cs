using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RISING.STAR.DAL;

namespace RISING.STAR.Business
{
    public abstract class BusinessBase
    {

        protected RISINGSTAREntities dbContext;

        public BusinessBase()
        {
            dbContext = new RISINGSTAREntities();
        }
        

    }
}

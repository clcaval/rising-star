using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RISING.STAR.DAL;

namespace RISING.STAR.Business.Login
{
    public class LocationBusiness
    {
        private RISINGSTAREntities dbContext;

        public LocationBusiness()
        {
            dbContext = new RISINGSTAREntities();
        }
        
        public IEnumerable<Location> RetrieveLocations()
        {
            return dbContext.Locations;
        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using RISING.STAR.Entities.OSI;
using RISING.STAR.DAL;

namespace RISING.STAR.Business.OSI
{
    public class OSITrendlineBusiness
    {

        private RISINGSTAREntities dbContext;

        public OSITrendlineBusiness()
        {
            dbContext = new RISINGSTAREntities();
        }

        public IEnumerable<Acquisitions_Table> RetrieveAcquisition()
        {
            return dbContext.Acquisitions_Table;
        }

        public IEnumerable<OSITrendlineData> RetrieveOSITrendline(Guid patientGuid, String eye, DateTime initialDate, DateTime finalDate)
        {

            var osiResult = new List<OSITrendlineData>();

            var acqList = this.RetrieveAcquisition().Where(
                                                    x => x.FK_Guid_Patient == patientGuid &&
                                                    x.OS_OD == eye && 
                                                    x.DATE >= initialDate &&
                                                    x.DATE <= finalDate);

           
            // TODO: one line this part
            foreach (var acq in acqList)
            {
                var aux = new OSITrendlineData();
                aux.Date = acq.DATE;
                aux.OSI = (float)acq.OSI;
                osiResult.Add(aux);
                
            }

            return osiResult;
        }


        public IEnumerable<InterventionCategory> GetAllCategories()
        {
            return dbContext.InterventionCategories;
        }

        public IEnumerable<InterventionType> GetAllInterventionTypes()
        {
            return dbContext.InterventionTypes;
        }

        public IEnumerable<InterventionEvent> GetAllEventsFromPatient(Guid patientGuid)
        {
            return dbContext.InterventionEvents.Where(x => x.PatientGuid == patientGuid);
        }
        
    }
}

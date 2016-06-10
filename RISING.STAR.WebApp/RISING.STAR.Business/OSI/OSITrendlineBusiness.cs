using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RISING.STAR.Utils.Helper;
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

        public IEnumerable<Acquisitions_Table> RetrieveAcquisition(Guid patientGuid, String eye, DateTime initialDate, DateTime finalDate)
        {
            
            eye = eye.Substring(1, 1);
            var acqList = this.RetrieveAcquisition().Where(
                                                    x => x.FK_Guid_Patient == patientGuid &&
                                                    x.OS_OD == eye &&
                                                    x.DATE >= initialDate &&
                                                    x.DATE <= finalDate &&
                                                    x.Type_Num == 2);

            return acqList.OrderBy(x => x.DATE);
        }

        public IEnumerable<OSITrendlineData> RetrieveOSITrendline(Guid patientGuid, String eye, DateTime initialDate, DateTime finalDate)
        {

            var osiResult = new List<OSITrendlineData>();
            var acqList = this.RetrieveAcquisition(patientGuid, eye, initialDate, finalDate);

            foreach (var acq in acqList)
            {
                var auxExterior = new OSITrendlineData();
                auxExterior.Date = new DateTime(acq.DATE.Year, acq.DATE.Month, 1);
                auxExterior.Value = (float)acq.OSI;
                auxExterior.DisplayX = acq.DATE.ToString("MMM/yyyy");
                osiResult.Add(auxExterior);
            }
            
            osiResult.OrderBy(x => x.Date);
            return this.RetrieveOSITrendlineTreated(osiResult, initialDate, finalDate);

            //return osiResult.OrderBy(x => x.Date);
        }

        public IEnumerable<OSITrendlineData> RetrieveOSITrendlineTreated(List<OSITrendlineData> osiData, DateTime initialDate, DateTime finalDate)
        {

            OSITrendlineData currentValue = null;
            var returnOsiData = new List<OSITrendlineData>();
            foreach (var osi in osiData)
            {
                if (currentValue == null)
                {
                    currentValue = osi;
                }
                else
                {

                    var diffMonths = ((osi.Date.Year - currentValue.Date.Year) * 12) + osi.Date.Month - currentValue.Date.Month;
                    var increment = (float)(osi.Value - currentValue.Value) / diffMonths;

                    foreach (DateTime month in DatetimeHelper.EachMonth(currentValue.Date.AddMonths(1), osi.Date.AddMonths(-1)))
                    {
                        var auxInterior = new OSITrendlineData();
                        auxInterior.Date = new DateTime(month.Year, month.Month, 1);
                        auxInterior.Value = currentValue.Value + increment;
                        auxInterior.DisplayX = month.ToString("MMM/yyyy");
                        returnOsiData.Add(auxInterior);
                        currentValue = auxInterior;
                    }

                    currentValue = osi;
                }
                returnOsiData.Add(osi);
            }

            returnOsiData.OrderBy(x => x.Date);

            foreach (DateTime month in DatetimeHelper.EachMonth(initialDate, finalDate))
            {
                var found = returnOsiData.Where(x => x.Date == month).FirstOrDefault();
                if(found == null)
                {
                    var auxInterior = new OSITrendlineData();
                    auxInterior.Date = new DateTime(month.Year, month.Month, 1);
                    auxInterior.Value = 0;
                    auxInterior.DisplayX = month.ToString("MMM/yyyy");
                    returnOsiData.Add(auxInterior);
                }
            }


            return returnOsiData.OrderBy(x => x.Date);
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

        public IEnumerable<InterventionEvent> GetAllEventsFromPatient(Guid patientGuid, string eye, DateTime date)
        {
            return this.GetAllEventsFromPatient(patientGuid).Where(
                                                                x => x.PatientGuid == patientGuid && 
                                                                x.Eye == eye && 
                                                                x.Date == date
                                                             );
        }

        private IEnumerable<String> GetIconsFromEvents(IEnumerable<InterventionEvent> events)
        {
            var strList = new List<String>();
            foreach (var item in events)
            {
                strList.Add(item.InterventionType.InterventionIcon.IconFileName);
            }
            return strList;
        }

        
    }
}

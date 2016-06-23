using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RISING.STAR.Utils.Helper;
using RISING.STAR.Entities.Charts;
using RISING.STAR.DAL;

namespace RISING.STAR.Business.Acquisition
{
    public class AcquisitionBusiness : BusinessBase
    {
        
        public IEnumerable<Acquisitions_Table> RetrieveAcquisition()
        {
            return this.dbContext.Acquisitions_Table;
        }

        public IEnumerable<Acquisitions_Table> RetrieveAcquisition(Guid patientId)
        {
            return this.dbContext.Acquisitions_Table.Where(x=> x.FK_Guid_Patient==patientId);
        }

        public IEnumerable<Acquisitions_Table> RetrieveAcquisition(Guid patientGuid, String eye, DateTime initialDate, DateTime finalDate, int type_num)
        {
            
            eye = eye.Substring(1, 1);
            var acqList = this.RetrieveAcquisition(patientGuid).Where(
                                                    x => x.OS_OD == eye &&
                                                    x.DATE >= initialDate &&
                                                    x.DATE <= finalDate &&
                                                    x.Type_Num == type_num);

            return acqList.OrderBy(x => x.DATE);
        }

        public IEnumerable<Acquisitions_Table> RetrieveAcquisition(Guid patientId, int examType)
        {
            var acqList = this.RetrieveAcquisition(patientId).Where(
                                                    x => x.Type_Num == examType);

            return acqList.OrderBy(x => x.DATE);
        }

        public IEnumerable<TrendlineData> RetrieveTrendlineTreated(List<TrendlineData> osiData, DateTime initialDate, DateTime finalDate)
        {

            TrendlineData currentValue = null;
            var returnOsiData = new List<TrendlineData>();
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
                        var auxInterior = new TrendlineData(new DateTime(month.Year, month.Month, 1),
                                                            currentValue.Value + increment,
                                                            month.ToString("MMM/yyyy"));
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
                if (found == null)
                {
                    var auxInterior = new TrendlineData(new DateTime(month.Year, month.Month, 1),
                                                        0,
                                                        month.ToString("MMM/yyyy"));
                    returnOsiData.Add(auxInterior);
                }
            }
            return returnOsiData.OrderBy(x => x.Date);
        }
        
    }
}

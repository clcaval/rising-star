using System;
using System.Collections.Generic;
using System.Linq;

using RISING.STAR.Business.Acquisition;
using RISING.STAR.Entities.Charts;

namespace RISING.STAR.Business.OSI
{
    public class OSITrendlineBusiness : AcquisitionBusiness
    {
        
        public IEnumerable<TrendlineData> RetrieveOSITrendline(Guid patientGuid, String eye, DateTime initialDate, DateTime finalDate)
        {
            var osiResult = new List<TrendlineData>();
            var acqList = base.RetrieveAcquisition(patientGuid, eye, initialDate, finalDate, 2);

            foreach (var acq in acqList)
            {
                var trendData = new TrendlineData();
                trendData.Date = new DateTime(acq.DATE.Year, acq.DATE.Month, 1);
                trendData.Value = (float)acq.OSI;
                trendData.DisplayX = acq.DATE.ToString("MMM/yyyy");
                osiResult.Add(trendData);
            }
            
            osiResult.OrderBy(x => x.Date);
            return this.RetrieveTrendlineTreated(osiResult, initialDate, finalDate);
        }

    }
}

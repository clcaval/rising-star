using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RISING.STAR.Business.Acquisition;
using RISING.STAR.Entities.Charts;

namespace RISING.STAR.Business.TearFilm
{
    public class TearFilmBusiness : AcquisitionBusiness
    {

        public IEnumerable<TrendlineData> RetrieveTearFilmTrendline(Guid patientGuid, String eye, DateTime initialDate, DateTime finalDate)
        {
            var osiResult = new List<TrendlineData>();
            var acqList = base.RetrieveAcquisition(patientGuid, eye, initialDate, finalDate, 5);

            foreach (var acq in acqList)
            {
                var trendData = new TrendlineData();
                trendData.Date = new DateTime(acq.DATE.Year, acq.DATE.Month, 1);
                trendData.Value = (float)acq.TearFilm_MeanOSI;
                trendData.DisplayX = acq.DATE.ToString("MMM/yyyy");
                osiResult.Add(trendData);
            }

            osiResult.OrderBy(x => x.Date);
            return this.RetrieveTrendlineTreated(osiResult, initialDate, finalDate);
        }

    }
}

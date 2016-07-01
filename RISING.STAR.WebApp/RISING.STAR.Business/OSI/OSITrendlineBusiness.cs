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


        public List<OSICohort> RetrieveOSICohort(int? ageFrom, int? ageTo, Guid? firstCriteria, Guid? secondCriteria, string timewindow, DateTime startDate, DateTime endDate)
        {

            var series = new List<OSICohort>();

            // TODO: finish this part
            //var acqs = dbContext.Acquisitions_Table.Where(x => x.Type_Num == 2);

            //if(ageFrom != null && ageFrom != null)
            //{
            //    acqs = acqs.Where(x => (DateTime.Now.Year - ((DateTime)x.Patients_Table.DATE_OF_BIRTH).Year > ageFrom) &&
            //                            (DateTime.Now.Year - ((DateTime)x.Patients_Table.DATE_OF_BIRTH).Year < ageTo)
            //                     );
            //}

            //if(firstCriteria != null && secondCriteria != null)
            //{



            //}


            var acqs = dbContext.Acquisitions_Table.Where(x => x.Type_Num == 2 &&   // SCT type
                                                                x.Patients_Table.DATE_OF_BIRTH != null &&   // has to have for age criteria
                                                                x.Patients_Table.InterventionEvents.Count() > 0 &&
                                                                    (x.Patients_Table.InterventionEvents.Any(s => s.InterventionTypeGuid == firstCriteria) ||
                                                                        x.Patients_Table.InterventionEvents.Any(s => s.InterventionTypeGuid == secondCriteria)
                                                                    ) &&
                                                                    (
                                                                        (DateTime.Now.Year - ((DateTime)x.Patients_Table.DATE_OF_BIRTH).Year > ageFrom) &&
                                                                        (DateTime.Now.Year - ((DateTime)x.Patients_Table.DATE_OF_BIRTH).Year < ageTo)
                                                                    )
                                                        );

            var firstCrit = acqs.Where(x => x.Patients_Table.InterventionEvents.Any(s => s.InterventionTypeGuid == firstCriteria)).ToList();
            var secondCrit = acqs.Where(x => x.Patients_Table.InterventionEvents.Any(s => s.InterventionTypeGuid == secondCriteria)).ToList(); 
            
            var osiCohort = new OSICohort();
            osiCohort.color = "rgba(223, 83, 83, .5)";
            osiCohort.name = dbContext.InterventionTypes.Where(x => x.InterventionGuid == firstCriteria).FirstOrDefault().Description;
            
            foreach (var acq in firstCrit)
            {
                double[] _data = { Math.Round((DateTime.Now - acq.DATE).TotalDays, 0), Math.Round((double)acq.OSI, 2) };
                osiCohort.data.Add(_data);
            }
            series.Add(osiCohort);

            if(secondCriteria != null)
            {
                osiCohort = new OSICohort();
                osiCohort.color = "rgba(119, 152, 191, .5)";
                osiCohort.name = dbContext.InterventionTypes.Where(x => x.InterventionGuid == secondCriteria).FirstOrDefault().Description;

                foreach (var acq in secondCrit)
                {
                    double[] _data = { Math.Round((DateTime.Now - acq.DATE).TotalDays, 0), Math.Round((double)acq.OSI, 2) };
                    osiCohort.data.Add(_data);
                }
                series.Add(osiCohort);
            }

            return series;

        }

    }
}

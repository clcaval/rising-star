using RISING.STAR.DAL;
using RISING.STAR.Utils.Helper;
using RISING.STAR.Entities.AcuDataTarget;
using System.Collections.Generic;
using System.Linq;
using System;

namespace RISING.STAR.Business.AcuDataMetrics
{
    public class AcuTargetMetricsBusiness
    {

        private RISINGSTAREntities dbContext;

        public AcuTargetMetricsBusiness() 
        {
            dbContext = new RISINGSTAREntities();
        }
    
        private IEnumerable<Acquisitions_Table> RetrieveAcquisitionsFromPatient(Guid patientId)
        {
            return dbContext.Acquisitions_Table.Where(x => x.FK_Guid_Patient == patientId);
        }

        public List<ObjectiveScatterIndex> RetrieveOSI(Guid patientId)
        {
            var osiList = new List<ObjectiveScatterIndex>();
            var acqList = this.RetrieveAcquisitionsFromPatient(patientId).Where(x => x.Type_Num == 2); // SCT
            foreach (var item in acqList)
            {
                osiList.Add(new ObjectiveScatterIndex(item.Id_Acq, 
                                                        DatetimeHelper.DatetimeToDDMMMYY(item.DATE),
                                                        DatetimeHelper.TimespanToHHmmTT(item.HOUR.TimeOfDay), 
                                                        "O"+item.OS_OD, 
                                                        (float)item.OSI));
            }
            return osiList;
        }
        
        public List<PseudoAccomodation> RetrievePseudoAccomodation(Guid patientId)
        {
            var paList = new List<PseudoAccomodation>();
            var acqList = this.RetrieveAcquisitionsFromPatient(patientId).Where(x => x.Type_Num == 3); // Pseudo Acc
            foreach (var item in acqList)
            {
                paList.Add(new PseudoAccomodation(item.Id_Acq,
                                                        DatetimeHelper.DatetimeToDDMMMYY(item.DATE),
                                                        DatetimeHelper.TimespanToHHmmTT(item.HOUR.TimeOfDay),
                                                        "O" + item.OS_OD,
                                                        (float)item.OAR));
            }
            return paList;
        }
        
        public List<TearFilmOSI> RetrieveTearFilmOSI(Guid patientId)
        {
            var tearFilmList = new List<TearFilmOSI>();
            var acqList = this.RetrieveAcquisitionsFromPatient(patientId).Where(x => x.Type_Num == 5); // Tear Film
            foreach (var item in acqList)
            {
                tearFilmList.Add(new TearFilmOSI(item.Id_Acq,
                                                    DatetimeHelper.DatetimeToDDMMMYY(item.DATE),
                                                    DatetimeHelper.TimespanToHHmmTT(item.HOUR.TimeOfDay),
                                                    "O" + item.OS_OD,
                                                    (float)item.TearFilm_MeanOSI,
                                                    (float)item.TearFilm_StdevOSI));
            }
            return tearFilmList;
        }
        
        public List<PurkinjeVSPupilMetrics> RetrievePurkinjeVsPupil(Guid patientId)
        {
            var purkList = new List<PurkinjeVSPupilMetrics>();
            var acqList = this.RetrieveAcquisitionsFromPatient(patientId).Where(x => x.Type_Num == 6);  // PKJ
            foreach (var item in acqList)
            {
                purkList.Add(new PurkinjeVSPupilMetrics(item.Id_Acq,
                                                    DatetimeHelper.DatetimeToDDMMMYY(item.DATE),
                                                    DatetimeHelper.TimespanToHHmmTT(item.HOUR.TimeOfDay),
                                                    "O" + item.OS_OD,
                                                    (float)item.PKJ_PkjVsPupil_Length,
                                                    (float)item.PKJ_PkjVsPupil_Angle,
                                                    (float)item.PKJ_PkjVsPupil_X,
                                                    (float)item.PKJ_PkjVsPupil_Y));
            }
            return purkList;
        }

        public List<InlayVsPurkinje> RetrieveInlayVsPurkinje(Guid patientId)
        {
            var purkList = new List<InlayVsPurkinje>();
            var acqList = this.RetrieveAcquisitionsFromPatient(patientId).Where(x => x.Type_Num == 6); // PKJ
            foreach (var item in acqList)
            {
                purkList.Add(new InlayVsPurkinje(item.Id_Acq,
                                                    DatetimeHelper.DatetimeToDDMMMYY(item.DATE),
                                                    DatetimeHelper.TimespanToHHmmTT(item.HOUR.TimeOfDay),
                                                    "O" + item.OS_OD,
                                                    (float)item.PKJ_InlayVsPkj_X,
                                                    (float)item.PKJ_InlayVsPkj_Y));
            }
            return purkList;
        }

    }
}

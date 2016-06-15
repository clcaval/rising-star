using RISING.STAR.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RISING.STAR.Entities.Charts;

namespace RISING.STAR.Business.Intervention
{
    public class InterventionBusiness : BusinessBase
    {

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

        public IEnumerable<InterventionData> GetAllEventsFromPatient(Guid patientGuid, string eye, DateTime initialDate, DateTime finalDate)
        {

            var events = this.GetAllEventsFromPatient(patientGuid).Where(
                                                                x => x.PatientGuid == patientGuid &&
                                                                x.Eye == eye &&
                                                                x.Date >= initialDate &&
                                                                x.Date <= finalDate
                                                             );
            var eventList = new List<InterventionData>();
            foreach (var item in events)
            {
                var aux = new InterventionData();
                aux.date = item.Date;
                aux.display = item.Date.ToString("MMM/yyyy");
                aux.icon = item.InterventionType.InterventionIcon.IconFileName;
                eventList.Add(aux);
            }

            return eventList;
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

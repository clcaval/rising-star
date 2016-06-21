using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RISING.STAR.DAL;
using RISING.STAR.Entities.Patients;

namespace RISING.STAR.Business.PatientBusiness
{
    public class PatientBusiness : BusinessBase
    {

        public List<Patient> RetrieveAllPatients()
        {
            var patients = new List<Patient>();
            foreach (var item in dbContext.Patients_Table)
            {
                patients.Add(new Patient(item.NAME + " " + item.SURNAME1, item.Guid));
            }
            return patients.OrderBy(m => m.Name).ToList();
        }

        public IEnumerable<PatientsComment> GetPatientComments(Guid patientId)
        {
            return dbContext.PatientsComments.Where(x => x.PatientId == patientId);
        }

        public IEnumerable<Document> GetPatientDocuments(Guid patientId)
        {
            return dbContext.Documents.Where(x => x.PatientId == patientId);
        }
        
    }
}

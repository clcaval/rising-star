using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RISING.STAR.DAL;
using RISING.STAR.Entities.Patients;

namespace RISING.STAR.Business.PatientBusiness
{
    public class PatientBusiness
    {

        private RISINGSTAREntities dbContext;

        public PatientBusiness()
        {
            dbContext = new RISINGSTAREntities();
        }

        public List<Patient> RetrieveAllPatients()
        {
            var patients = new List<Patient>();

            foreach (var item in dbContext.Patients_Table)
            {
                patients.Add(new Patient(item.NAME + " " + item.SURNAME1, item.Guid));
            }
            return patients.OrderBy(m => m.Name).ToList();
        }

    }
}

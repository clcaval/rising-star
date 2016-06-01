using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISING.STAR.Entities.Patients
{
    public class Patient
    {

        public string Name { get; set; }
        public Guid Id { get; set; }

        public Patient(string _name, Guid _id)
        {
            this.Name = _name;
            this.Id = _id;
        }

    }
}

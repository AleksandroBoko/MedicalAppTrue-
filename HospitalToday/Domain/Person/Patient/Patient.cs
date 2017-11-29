using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Domain.Person.Patient
{
    class Patient : Person
    {
        public int DoctorId { get; set; }
        public int Age { get; set; }
    }
}

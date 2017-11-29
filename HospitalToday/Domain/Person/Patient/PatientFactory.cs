using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Domain.Person.Patient
{
    class PatientFactory : PersonFactory
    {
        public override Person GetPerson()
        {
            return new Patient();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Domain.Person.Doctor
{
    class DoctorFactory : PersonFactory
    {
        public override Person GetPerson()
        {
            return new Doctor();
        }
    }
}

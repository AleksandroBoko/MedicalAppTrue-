using HospitalToday.Common.Models;
using HospitalToday.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Domain.Factory.Implementation
{
    class PatientFactory : PersonFactory
    {
        public override Person GetPerson()
        {
            return new Patient();
        }
    }
}

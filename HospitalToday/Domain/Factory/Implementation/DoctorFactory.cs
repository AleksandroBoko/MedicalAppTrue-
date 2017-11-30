using HospitalToday.Common.Models;
using HospitalToday.Domain.Factory;
using HospitalToday.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Domain.Factory.Implementation
{
    class DoctorFactory : PersonFactory
    {
        public override Person GetPerson()
        {
            return new Doctor();
        }
    }
}

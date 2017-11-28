using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Domain
{
    interface IDoctorService
    {
        void Add(Person person);
        void Remove(Person person);
    }
}

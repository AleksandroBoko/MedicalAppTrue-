using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Domain.Person
{
    abstract class PersonFactory
    {
        public abstract Person GetPerson();
    }
}

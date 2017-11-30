using HospitalToday.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Domain.Factory
{
    abstract class PersonFactory
    {
        public abstract Person GetPerson();
    }
}

using HospitalToday.Common.Models;
using HospitalToday.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Domain.Factory.Implementation
{
    class FebrifugeFactory : MedicineFactory
    {
        public override Medicine GetMedicine()
        {
            return new Febrifuge();
        }
    }
}

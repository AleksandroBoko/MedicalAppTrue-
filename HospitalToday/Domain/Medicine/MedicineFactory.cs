using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Domain.Medicine
{
    abstract class MedicineFactory
    {
        public abstract Medicine GetMedicine();
    }
}

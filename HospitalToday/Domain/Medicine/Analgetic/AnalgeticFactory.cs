using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Domain.Medicine.Analgetic
{
    class AnalgeticFactory : MedicineFactory
    {
        public override Medicine GetMedicine()
        {
            return new Analgetic();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Domain.Medicine.Febrifuge
{
    class FebrifugeFactory : MedicineFactory
    {
        public override Medicine GetMedicine()
        {
            return new Febrifuge();
        }
    }
}

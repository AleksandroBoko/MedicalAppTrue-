using HospitalToday.Domain;
using HospitalToday.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Logic
{
    class MedicineService : IService<Medicine>
    {
        IRepository<Medicine> MedicineRep;

        public MedicineService()
        {
            MedicineRep = new MedicineRepository();
        }

        public void Add(Medicine item)
        {
            MedicineRep.Create(item);
        }

        public void Remove(Medicine item)
        {
            MedicineRep.Delete(item.Id);
        }
    }
}

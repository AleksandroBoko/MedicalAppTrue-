using HospitalToday.Domain;
using HospitalToday.Domain.Medicine;
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
        IRepository<Medicine> medicineRep;

        public MedicineService()
        {
            medicineRep = MedicineRepository.GetRepository();
        }

        public void Add(Medicine item)
        {
            medicineRep.Create(item);
        }

        public void Remove(Medicine item)
        {
            medicineRep.Delete(item.Id);
        }
    }
}

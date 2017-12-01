using HospitalToday.Common.Models;
using HospitalToday.DataAccess;
using HospitalToday.DataAccess.Implementation;
using HospitalToday.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Services.Implementation
{
    class MedicineService : IMedicineService
    {
        private readonly IRepository<Medicine> medicineRep;

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

        public IList<Medicine> GetList()
        {
            return medicineRep.GetList();
        }

        public Medicine GetItemById(int id)
        {
            return medicineRep.GetItem(id);
        }
    }
}

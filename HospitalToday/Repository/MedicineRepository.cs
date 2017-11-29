using HospitalToday.Domain;
using HospitalToday.Domain.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Repository
{
    class MedicineRepository : IRepository<Medicine>
    {
        private static IRepository<Medicine> medicineRep;
        private readonly List<Medicine> medicines;

        private MedicineRepository()
        {
            medicines = new List<Medicine>();
        }

        public static IRepository<Medicine> GetRepository()
        {
            if (medicineRep == null)
            {
                medicineRep = new MedicineRepository();
            }

            return medicineRep;
        }

        public void Create(Medicine item)
        {
            medicines.Add(item);
        }

        public void Delete(int id)
        {
            if (medicines.Any(x => x.Id == id))
            {
                medicines.Remove(medicines.FirstOrDefault(x => x.Id == id));
            }
        }

        public Medicine GetItem(int id)
        {
            return medicines.FirstOrDefault(x => x.Id == id);
        }

        public List<Medicine> GetList()
        {
            return medicines;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Medicine item)
        {
            throw new NotImplementedException();
        }
    }
}

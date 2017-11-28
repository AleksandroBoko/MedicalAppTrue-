using HospitalToday.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Repository
{
    class MedicineRepository : IRepository<Medicine>
    {
        private static IRepository<Medicine> MedRep;

        List<Medicine> Medicines;

        private MedicineRepository()
        {
            Medicines = new List<Medicine>();
        }

        public static IRepository<Medicine> GetRepository()
        {
            if (MedRep == null)
                MedRep = new MedicineRepository();

            return MedRep;
        }

        public void Create(Medicine item)
        {
            Medicines.Add(item);
        }

        public void Delete(int id)
        {
            Medicines.Remove(Medicines.Where(m => m.Id == id).First());
        }

        public Medicine GetItem(int id)
        {
            return Medicines.Where(m => m.Id == id).First();
        }

        public List<Medicine> GetList()
        {
            return Medicines;
        }

        public void Save()
        {
            // TODO add code;
        }

        public void Update(Medicine item)
        {
            // TODO add code;
        }
    }
}

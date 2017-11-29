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
        private static IRepository<Medicine> medRep;
        private List<Medicine> medicines;

        private MedicineRepository()
        {
            medicines = new List<Medicine>();
        }

        public static IRepository<Medicine> GetRepository()
        {
            if (medRep == null)
                medRep = new MedicineRepository();

            return medRep;
        }

        public void Create(Medicine item)
        {
            medicines.Add(item);
        }

        public void Delete(int id)
        {
            var t = medicines.FirstOrDefault(m => m.Id == id);
            if (t != null)
            {
                medicines.Remove(t);
            }
        }

        public Medicine GetItem(int id)
        {
            return medicines.FirstOrDefault(m => m.Id == id);
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

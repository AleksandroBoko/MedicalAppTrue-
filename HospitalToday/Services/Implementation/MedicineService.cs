﻿using HospitalToday.Common.Models;
using HospitalToday.DataAccess;
using HospitalToday.DataAccess.Implementation;
using HospitalToday.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Logic
{
    class MedicineService : IService<Medicine>
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

        public List<Medicine> GetList()
        {
            return medicineRep.GetList();
        }
    }
}

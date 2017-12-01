using HospitalToday.Common.Models;
using HospitalToday.DataAccess;
using HospitalToday.DataAccess.Implementation;
using HospitalToday.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalToday.Services.Implementation
{
    class DoctorService : IService<Person>
    {
        private readonly IRepository<Person> personRep;

        public DoctorService()
        {
            personRep = PersonRepository.GetRepository();
        }

        public void Add(Person item)
        {
            personRep.Create(item);
        }

        public void Remove(Person item)
        {
            personRep.Delete(item.Id);
        }

        public List<Person> GetList()
        {
            var persons = personRep.GetList().Where(x => x is Doctor);
            return persons != null ? persons.ToList() : null;
        }

        public Report GetReport(Person doctor, Person patient, List<Medicine> medicines, DateTime date)
        {
            if (doctor == null || patient == null)
            {
                return null;
            }

            DateTime currentDate = date == null ? DateTime.Now : date;

            return new Report()
            {
                DoctorId = doctor.Id,
                PatientId = patient.Id,
                Date = currentDate,
                Medicines = medicines
            };
        }

        public Person GetItemById(int id)
        {
            return personRep.GetItem(id);
        }
    }
}

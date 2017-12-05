using HospitalToday.Common.Models;
using HospitalToday.DataAccess;
using HospitalToday.DataAccess.Implementation;
using HospitalToday.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalToday.Services.Implementation
{
    class DoctorService : IDoctorService
    {
        public DoctorService()
        {
            personRep = PersonRepository.GetRepository();
            reportService = new ReportService();
        }

        private readonly IRepository<Person> personRep;
        private readonly IService<Report> reportService;

        public void Add(Person item)
        {
            personRep.Create(item);
        }

        public void Remove(Person item)
        {
            personRep.Delete(item.Id);
        }

        public IList<Person> GetList()
        {
            return personRep.GetList().Where(x => x is Doctor).ToList();
        }

        public Person GetItemById(int id)
        {
            return personRep.GetItem(id);
        }

        public int CreateReport(Person doctor, Person patient, List<Medicine> medicines, DateTime? date)
        {
            if (doctor == null || patient == null)
            {
                throw new ArgumentException("One of the required parameters is null");
            }

            var currentDate = date ?? DateTime.Now;

            var report = new Report()
            {
                DoctorId = doctor.Id,
                PatientId = patient.Id,
                Date = currentDate,
                Medicines = medicines
            };

            reportService.Add(report);

            return report.Id;
        }

        public int GetMaxId()
        {
            var persons = personRep.GetList();
            return persons.Any() ? persons.Max(x => x.Id) : 0;
        }
    }
}

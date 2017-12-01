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
        private readonly IRepository<Person> personRep;
        private readonly IService<Report> reportService;

        public DoctorService()
        {
            personRep = PersonRepository.GetRepository();
            reportService = new ReportService();
        }

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
            var persons = personRep.GetList().Where(x => x is Doctor);
            return persons.ToList();
        }

        public Person GetItemById(int id)
        {
            return personRep.GetItem(id);
        }

        public int CreateReport(Person doctor, Person patient, List<Medicine> medicines, DateTime? date)
        {
            var resultId = -1;
            if (doctor == null || patient == null)
            {
                return resultId;
            }

            DateTime currentDate = date ?? DateTime.Now;

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

    }
}

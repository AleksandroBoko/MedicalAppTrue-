using HospitalToday.Domain;
using HospitalToday.Domain.Medicine;
using HospitalToday.Domain.Person;
using HospitalToday.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday
{
    static class Initializer
    {
        static IService<Medicine> MedService;
        static IService<Person> Persons;
        static IService<Report> Reports;

        
        public static void InitServices()
        {
            MedService = new MedicineService();
            Persons = new PersonService();
            Reports = new ReportService();
        }

        public static void AddingPersons()
        {
            Persons.Add()
        } 
    }
}

using HospitalToday.Domain;
using HospitalToday.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday
{
    class Program
    {
        static IService<Medicine> MedService;
        static IService<Person> Doctors;
        static IService<Person> Patients;
        static IService<Report> Reports;

        static void Main(string[] args)
        {
            InitServices();
        }

        static void InitServices()
        {
            MedService = new MedicineService();
            Doctors = new PersonService();
            Patients = new PersonService();
            Reports = new ReportService();
        }


    }
}

using HospitalToday.Common.Models;
using HospitalToday.Domain;
using HospitalToday.Domain.Models;
using HospitalToday.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday
{
    class Program
    {
        private static IService<Medicine> medicines;
        private static IService<Person> doctors;
        private static IService<Person> patients;
        private static IService<Report> reports;


        static void Main(string[] args)
        {
            Initializer.InitServices(medicines,doctors,patients,reports);

            Initializer.AddingPersons();
            Initializer.AddingMedicine();

            Console.ReadKey();
        }

    }
}

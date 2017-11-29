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
    class Program
    {

        static void Main(string[] args)
        {
            Initializer.InitServices();
            Initializer.AddingPersons();
            Initializer.ShowDoctors();
            Initializer.ShowPatients();

            Console.ReadKey();
        }

    }
}

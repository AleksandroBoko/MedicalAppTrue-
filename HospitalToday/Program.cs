using HospitalToday.Domain;
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
            Initializer.AddingMedicine();

            Console.ReadKey();
        }

    }
}

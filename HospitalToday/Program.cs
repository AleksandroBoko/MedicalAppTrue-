using HospitalToday.Common.Models;
using HospitalToday.Domain;
using HospitalToday.Domain.Models;
using HospitalToday.Services;
using HospitalToday.Services.Implementation;
using HospitalToday.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday
{
    class Program
    {
        private static IMedicineService medicines;
        private static IDoctorService doctors;
        private static IPatientService patients;
        private static IReportService reports;
        private static MenuHandler menuHandler;

        static void Main(string[] args)
        {
            medicines = new MedicineService();
            doctors = new DoctorService();
            patients = new PatientService();
            reports = new ReportService();

            Initializer.InitServices(medicines,doctors,patients,reports);

            Initializer.AddingPersons();
            Initializer.AddingMedicine();

            menuHandler = new MenuHandler(medicines, doctors, patients, reports);
            menuHandler.MainMenuHandler();

            Console.ReadKey();
        }

    }
}
